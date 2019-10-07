using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //declare variables
    private Transform target;
    public float range = 15;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // repeat UpdateTarget every .5seconds
    }

    void UpdateTarget ()
    {
        // This function updates less frequently than update to save resources. 

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies) //cycle through all enemies and see which one is closest nearestEnemy is set to closest enemy
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if( shortestDistance > distanceToEnemy)
            {
                nearestEnemy = enemy;
                shortestDistance = distanceToEnemy;
            }
        }
        if (nearestEnemy != null  && shortestDistance <= range)// if there is a nearest enemy and they are within range then make them the target;
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation ,lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range); //puts a wire spere around turret for range in dev mode
    }
}
