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
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn >= spawnRate)
        {
            SpawnEnemy(0);
        }
    }
    public void SpawnEnemy(int enemyNum)
    {
        Instantiate(enemy[enemyNum], gameObject.transform.position, gameObject.transform.rotation);
        timeSinceSpawn = 0;
    }
}
