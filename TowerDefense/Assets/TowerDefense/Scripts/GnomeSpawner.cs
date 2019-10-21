using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeSpawner : MonoBehaviour
{
    //declare variables
    public  GameObject[] enemy;
    public float spawnRate; // seconds between spawns
    private float timeSinceSpawn = 0;
    // Start is called before the first frame update

    void Start()
    {
        SpawnEnemy(0);
    }

    // Update is called once per frame
    void Update()
    {
        RepeatSpawn(); //this function repeatidly spawns gnomes it must be run in Update()
    }
    private void SpawnEnemy(int enemyNum)
    {
        Instantiate(enemy[enemyNum], gameObject.transform.position, gameObject.transform.rotation); //spawns enemy (based on enemynum)
        timeSinceSpawn = 0; //resets time since last spawn
    }

    private void RepeatSpawn()//this function repeatidly spawns gnomes it must be run in Update()
    {
        timeSinceSpawn += Time.deltaTime; // Updates the time since the last spawn
        if (timeSinceSpawn >= spawnRate) // if enough time has passed since last spawn
        {
            SpawnEnemy(0);
        }
    }
}
