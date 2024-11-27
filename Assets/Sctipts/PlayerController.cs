using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    public NavMeshAgent Player;
    public GameObject hitMarker;
    public GameObject placedMarker;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//Getting the left click of the mouse
        {
            
            //When it is clicked getting the position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Handing in the position when clicked and spitting where it hit
            if (Physics.Raycast(ray, out hit))
            {
                //Destroy my placedMarker is it isn't empty
                if (placedMarker != null)
                {
                    Destroy(placedMarker);
                }
                //Setting my player to move towards my hit
                Player.SetDestination(hit.point);
               placedMarker = Instantiate(hitMarker, hit.point, Quaternion.identity);
            }
        }
    }
}
