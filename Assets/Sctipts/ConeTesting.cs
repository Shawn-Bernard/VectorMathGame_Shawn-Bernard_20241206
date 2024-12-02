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
      Vector3 PlayerPosition = Player.transform.position.normalized;

      Vector3 EnemyPosition = transform.position.normalized;

      Vector3 distance =  EnemyPosition - PlayerPosition;

        
        

        
        if (DetectPlayer() == true)
        {
            
           


        }
        


        
        
    }
    bool DetectPlayer()
    {

        Vector3 PlayerPosition = Player.transform.position;
        Vector3 EnemyPosition = transform.position;
        Vector3 distance = PlayerPosition - EnemyPosition;
        RaycastHit hit;
        float CosTheta = Vector3.Dot(transform.forward, distance);
        float Angle = Mathf.Acos(CosTheta) * Mathf.Rad2Deg;
        if (distance.magnitude <= Range)
        {
            if (Physics.Raycast(transform.position, distance.normalized, out hit, 300))
            {

                if (hit.collider.tag == "Player")
                {
                    if (Angle <= ConeAngle)
                    {
                        Debug.Log("In Cone");
                    }
                    
                }
            }
        }
        return false;
    }
}

