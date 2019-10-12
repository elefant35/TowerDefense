using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyController : MonoBehaviour
{
    //declare variables

    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public GameObject Goal;
    public float health = 10f;

    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {

        EnemyMovement();
        AnimateWalk();

        if(health <= 0)
        {
            Die();
        }
    }

    void AnimateWalk()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }

    void getPlayerDirection() //used for testing to move gnomes to desired area
    {
        if (Input.GetMouseButtonDown(0)) //if mouse is clicked
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
    void EnemyMovement()
    {
        agent.SetDestination(Goal.transform.position);
    }

    public void DamageEnemy(float damage)
    {
        health -= damage;
    }

    public void Die()
    {
        Debug.Log("enemy has died");
        Destroy(gameObject);
    }
}
