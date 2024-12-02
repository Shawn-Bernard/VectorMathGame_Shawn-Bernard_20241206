using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public GameObject player;
    public float range; //radius of zone
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        if (distance <= range)
        {
            enemy.SetDestination(player.transform.position);
        }
        else if (enemy.remainingDistance <= enemy.stoppingDistance) // If done moving
        {
            //Throwing is my target vector
            if (Randomtarget(ref target))//if true do this
            {
                enemy.SetDestination(target);// using whatever vector it spits out by ref
            }
        }
    }
    bool Randomtarget(ref Vector3 newtarget)
    {
        Vector3 randTarget = Random.insideUnitSphere * range;// Random target inside a sphere unit
        NavMeshHit hit;
        //taking randtarget, puting out my hit on mesh with the distance of range and checking all areas on mesh
        if (NavMesh.SamplePosition(randTarget, out hit, range, NavMesh.AllAreas))
        {
            newtarget = hit.position;//making my target 
            return true;
        }
        else
        {
            return false;
        }
    }

    
       

}
