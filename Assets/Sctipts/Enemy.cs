using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;

    public GameObject player;
    public GameObject gameOverScreen;

    int coneAngle = 80;
    int range = 6;
    int searchRange = 20;
    int caughtRange = 2;

    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectPlayer())
        {
            DetectPlayer();
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
    bool DetectPlayer()
    {
        Vector3 distance = player.transform.position - transform.position;
        float CosTheta = Vector3.Dot(transform.forward, distance.normalized);
        float Angle = Mathf.Acos(CosTheta) * Mathf.Rad2Deg;
        RaycastHit hit;
        //If my distance is less than range, so within range 
        if (distance.magnitude <= range)
        {
            //Shooting out a ray cast from my enemy position to the distance of the player
            if (Physics.Raycast(transform.position, distance.normalized, out hit, range))
            {
                //If my hit collided with my player tag returns true
                if (hit.collider.tag == "Player")
                {
                    if (Angle <= coneAngle / 2)
                    {
                        enemy.SetDestination(player.transform.position);
                        if (distance.magnitude <= caughtRange)
                        {
                            PlayerController.Caught = true;
                        }
                        return true;
                    }
                    else 
                    { 
                        return false; 
                    }
                }
            }
        }
        return false;
    }
    bool Randomtarget(ref Vector3 newtarget)
    {

        Vector3 randTarget = player.transform.position + Random.insideUnitSphere * searchRange;// Random target inside a sphere unit
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
