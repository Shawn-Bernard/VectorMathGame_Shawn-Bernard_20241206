using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeTesting : MonoBehaviour
{
    public GameObject Player;
    int ConeAngle = 80;
    public int Range = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 PlayerPosition = Player.transform.position;

      Vector3 EnemyPosition = transform.position;

      Vector3 distance = PlayerPosition - EnemyPosition;

      Vector3 forward = transform.TransformDirection(Vector3.forward);

        float angle = Vector3.Dot(forward, distance);
        float degrees = Mathf.Acos(angle) * Mathf.Rad2Deg;
        
        //Checking if my dot is 0 meaning behind player
        if (Vector3.Dot(forward,distance) < 0)
        {
            
        }

        float CosTheta = Vector3.Dot(transform.forward, distance.normalized);
        float Angle = Mathf.Acos(CosTheta) * Mathf.Rad2Deg;

        if (DetectPlayer() == true)
        {
            if (Angle <= ConeAngle / 2)
            {
                Debug.Log("In Cone");
            }
        }
        
        

        




    }
    bool DetectPlayer()
    {

        Vector3 PlayerPosition = Player.transform.position;
        Vector3 EnemyPosition = transform.position;
        Vector3 distance = PlayerPosition - EnemyPosition;
        RaycastHit hit;
        
        if (distance.magnitude <= Range)
        {
            if (Physics.Raycast(transform.position, distance.normalized, out hit, Range))
            {

                if (hit.collider.tag == "Player")
                {

                    return true;
                }
            }
        }
        return false;
    }
}

