using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawnpointController : MonoBehaviour
{
    //declare variables
    public Transform spawnPoint;
    public GameObject turret;
    public GameObject turretToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spawnTurret();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnTurret()
    {
        turret = (GameObject)Instantiate(turretToSpawn, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Turret was spawned");
    }
}
