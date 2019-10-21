using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //declare variables-----------------------------------------
    private Transform target;
    [Header("Modifiable attributes")]
    [SerializeField] private float range = 15;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private float fireRate = 1f; // number of times turret shoots in one second
    private float fireCountdown = 0f;

    [Header("Set up")]
    [SerializeField] private Transform partToRotate; // pivot point for the turet (containing object for the turret)
    [SerializeField] private string enemyTag = "Enemy"; // tag that turret will lock on to
    [SerializeField] private GameObject bulletPrefab; // bullet that is fired
    [SerializeField] private Transform firePoint; // point where the bullet is released

    //System managed functions -------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // repeat UpdateTarget every .5seconds
    }

    // Update is called once per frame
    void Update()
    {
        rotateAndFire();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range); //puts a wire spere around turret for range in dev mode
    }


    // Custom Functions------------------------------------------------
    private void Shoot()
    {
        //Debug.Log("shoot at : " + target.name); //Debug code to see what target the turret is aiming at
        GameObject flyingBullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //generates teh bullet at the firepoint
        Bullet bullet = flyingBullet.GetComponent<Bullet>(); //gets the script for the bullet object

        if(bullet  != null)
        {
            //Debug.Log("bulletScript was called");
            bullet.Seek(target); //sets the target for the bullet
        }
    }

    private void rotateAndFire()
    {
        if (target == null)
        {
            return;
        }

        //rotating to look at enemy
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; //lerp makes the rotation smoother
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        //shooting
        if (fireCountdown <= 0) 
        {
            Shoot();
            fireCountdown = 1f / fireRate; //fire rate is number of times turret shoots in one second
        }
        fireCountdown -= Time.deltaTime; //counts down till next shot
    }
    private void UpdateTarget()
    {
        // This function updates less frequently than update to save resources. 

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies) //cycle through all enemies and see which one is closest nearestEnemy is set to closest enemy
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (shortestDistance > distanceToEnemy)
            {
                nearestEnemy = enemy;
                shortestDistance = distanceToEnemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)// if there is a nearest enemy and they are within range then make them the target;
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

}
