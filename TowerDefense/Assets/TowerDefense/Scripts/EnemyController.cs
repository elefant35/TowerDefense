using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Selectable variables
    public GameObject Goal;
    public NavMeshAgent EnemyNavMesh;
    //Non-Selectable variables

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }
    
    void EnemyMovement()
    {
        EnemyNavMesh.SetDestination(Goal.transform.position);
    }

}
