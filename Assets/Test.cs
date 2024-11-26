using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{

    public GameObject player;
    public GameObject PointA;
    public GameObject PointB;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float rand = Random.RandomRange(5f, 10f);
        Vector3 Direction = (transform.position - player.transform.position);
        
        if (Direction.magnitude == 6)
        {
            transform.forward = Direction;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
            Gizmos.color = Color.green;
        }
        else
        {
            if (transform.position == PointA.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, PointB.transform.position, Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, PointA.transform.position, Time.deltaTime);
            }
            Vector3 DirectionA = (transform.position - transform.position);
            Gizmos.color = Color.red;

        }
        Gizmos.DrawLine(transform.position, player.transform.position);
    }
    private void OnDrawGizmos()
    {
        
    }


}
