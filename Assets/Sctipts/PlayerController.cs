using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    public NavMeshAgent Player;

    public GameObject hitMarker;
    public GameObject placedMarker;
    public GameObject gameOverScreen;
    public GameObject winScreen;

    public TMP_Text playerUI;
    public int boxCount = 0;

    public static bool Caught = false;

    private void Awake()
    {
        Caught = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        Controller();
        UI();


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            Debug.Log("box");
            Destroy(other.gameObject);//Destroying other object
            boxCount++;
        }
    }
    void UI()
    {
        playerUI.text = $"Boxes: {boxCount}/3";
        if (boxCount >= 3)
        {
            winScreen.SetActive(true);
        }
    }
    void Controller()
    {
        if (Input.GetMouseButtonDown(0))//Getting the left click of the mouse
        {

            //When it is clicked getting the position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Handing in the position when clicked and spitting out where it hit
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
    void GameOver()
    {
        if (Caught == true)
        {
            gameOverScreen.SetActive(true);
        }
        else
        {
            gameOverScreen.SetActive(false);
        }
    }
}
