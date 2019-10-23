using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawnpointController : MonoBehaviour
{
    //declare variables
    [SerializeField] private Transform spawnPoint; // The point where the turret will spawn
    [SerializeField] private GameObject[] turretLibrary; // using an array so I can add additional turrets in the future
    private GameObject currentTurret; // keeps track of current turret in case modifations to turret need to be made, eg. upgrades. 
    private int currentTurretNum = -1;
    private bool hasTurret = false; //shows if this turret spawn point currently has a turret 
    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        //ChangeTurret(0);// used for testing remove later
    }

    // Update is called once per frame
    void Update()
    {
        clickController();   
    }

    private GameObject spawnTurret( GameObject turretToSpawn)
    {
        Debug.Log(turretToSpawn.name + "was spawned"); //logs what turret was spawned
        hasTurret = true; //sets hasTurret to true to show that the spawnpoint has a turret
        return (GameObject)Instantiate(turretToSpawn, spawnPoint.position, spawnPoint.rotation); //spawns turret and 
        
    }

    public GameObject returnCurrentTurret() // used to return the current turret so outside scripts can  see what turret is being used without modifying it
    {
        return currentTurret;
    }

    public int returnCurrentTurretNum() //used to return the number of the current turret
    {
        return currentTurretNum;
            
    
    }


    public bool removeTurret()
    {
        if (hasTurret)
        {
            //remove turret
            hasTurret = false; //sets has turret to false to show no turret is in use
            Destroy(currentTurret); //destroys the turret gameobject
            currentTurret = null; //sets currentTurret to null to reperesent that no turret is in use
            currentTurretNum = -1;
            return true; //returns true for error handling to show that the function was sucessful
        }
        else
        {
            return false; // there is currently no turret so false is returned for error handling
        }
    }

    public bool returnHasTurret()
    {
        return hasTurret;
    }

    public bool ChangeTurret(int turretNumber) // adds a turret or changes it regardless of existing turret in spawnpoint
    {
        if (hasTurret)
        {
            removeTurret(); // if there is a turret then remove it
        }
        currentTurret = spawnTurret(turretLibrary[turretNumber]); //spawn a turret
        currentTurretNum = turretNumber; //set currentTurret num to the library number of the turret that was spawned.
        return true; //return true for error handling
    }

    private void clickController() { // used to track if the game object is cliecked, must be run in update()
        if (Input.GetMouseButtonDown(0)) //if mouse is clicked
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("hit: " + hit.transform.gameObject.name);
                if(hit.transform.gameObject == gameObject)
                {
                    Debug.Log("The Turret Spawn Point Was clicked");
                    ChangeTurret(0);
                }
            }
        }

    }

}
