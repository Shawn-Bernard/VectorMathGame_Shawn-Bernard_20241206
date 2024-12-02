using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float rand = Random.RandomRange(5f, 10f);
        Vector3 Direction = player.transform.position - transform.position;
        
        if (Direction.magnitude <= 6)
        {
            transform.forward = Direction;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
            Gizmos.color = Color.red;
        }
        else
        {

            Gizmos.color = Color.green;

        }
        Gizmos.DrawLine(transform.position, player.transform.position);
    }


}
