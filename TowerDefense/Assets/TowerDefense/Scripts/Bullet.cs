using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Declare Variables

    private Transform target;
    public float speed = 60f;
    public float damageAmount = 5f;

    // Update is called once per frame
    void Update()
    {
        bulletFly();


    }
    public void Seek (Transform bulletTarget)
    {
        target = bulletTarget;
    }

    void bulletFly()
    {
        if (target == null)
        {
            Destroy(gameObject);//destroy the bullet if the target is somehow missing. ie. it died before bullet hits
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    
    void HitTarget()
    {
        //Debug.Log("We Hit Something"); // Used to show that something was hit
        Destroy(gameObject);
        EnemyController enemyController = target.GetComponent<EnemyController>();
        enemyController.DamageEnemy(damageAmount);
    }
}
