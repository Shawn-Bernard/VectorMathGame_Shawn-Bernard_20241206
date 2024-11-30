using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeTesting : MonoBehaviour
{
    public GameObject Player;
    public int ConeAngle = 40;
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

      Vector3 distance = PlayerPosition - EnemyPosition ;

     float CosTheta = Vector3.Dot(transform.forward, distance);
     float Angle =   Mathf.Acos(CosTheta) * Mathf.Rad2Deg;
        if (Angle <= ConeAngle * 0.5)
        {
            Debug.Log("In Cone");
        }
        
        float playerdot = Vector3.Dot(PlayerPosition, distance);
        Debug.Log(Angle);
    }
    bool DetechPlayer()
    {
        Vector3 PlayerPosition = Player.transform.position.normalized;
        Vector3 EnemyPosition = transform.position.normalized;
        Vector3 distance = PlayerPosition - EnemyPosition;
        if (distance.magnitude <= Range)
        {
            //if(Physics.Raycast(transform.position,transform.forward, ))

            //after if do logic for finding if player is in cone
        }
    }
}
