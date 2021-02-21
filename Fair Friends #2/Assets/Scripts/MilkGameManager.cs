using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MilkGameManager : MonoBehaviour
{
    public static MilkGameManager Instance;
    public AudioSource click;

    private void Awake()
    {
        GlobalControl.Instance.AtMainMenu = false;
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private Camera camera;
    public Trajectory traj;
    public Ball ball;
    public MiniGameDialogue mgD;
    public GameObject winScreen;
    public GameObject dialogueBox;
    public GameObject stand;
    [SerializeField] float pushForce = 4f;

    bool isDragging = false;

    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 direction;
    private Vector2 force;
    private float distance;


    private void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(mgD);
        camera = Camera.main;
        ball.DeactiveateRb();
        winScreen.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnDragEnd();
        }

        if(isDragging)
        {
            OnDrag();
        }

        CheckBottlesPos();
    }

    private void OnDragStart()
    {
        ball.DeactiveateRb();
        startPos = camera.ScreenToWorldPoint(Input.mousePosition);

        traj.Show();
    }
    private void OnDrag()
    {
        endPos = camera.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPos, endPos);
        direction = (startPos - endPos).normalized;
        force = direction * distance * pushForce;

        Debug.DrawLine(startPos, endPos);

        traj.UpdateDots(ball.Position, force);

    }
    private void OnDragEnd()
    {
        ball.ActiveateRb();
        ball.Push(force);

        traj.Hide();
    }

    private void CheckBottlesPos()
    {
        if(!winScreen.activeSelf)
        {
            GameObject[] tempMilkBottleCollection = GameObject.FindGameObjectsWithTag("MilkBottle");
            int bottlesKnocked = 0;
            for (int i = 0; i < tempMilkBottleCollection.Length; i++)
            {

                if (tempMilkBottleCollection[i].transform.position.y < -3)
                {
                    bottlesKnocked++;
                }

                if (bottlesKnocked == 3)
                {
                    GlobalControl.Instance.Followers++;
                    dialogueBox.SetActive(false);
                    click.Play();
                    winScreen.SetActive(true);
                }
            }
        }
    }

    public void ResetBottles()
    {
        Vector3 standsOffset = stand.transform.position;
        GameObject[] tempMilkBottleCollection = GameObject.FindGameObjectsWithTag("MilkBottle");
        tempMilkBottleCollection[0].transform.position = new Vector3(.9f, 0, 0);
        tempMilkBottleCollection[0].transform.rotation = Quaternion.Euler(0,0,0);
        tempMilkBottleCollection[0].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        tempMilkBottleCollection[0].GetComponent<Rigidbody2D>().angularVelocity = 0;

        tempMilkBottleCollection[1].transform.position = new Vector3(1.8f, 0, 0);
        tempMilkBottleCollection[1].transform.rotation = Quaternion.Euler(0, 0, 0);
        tempMilkBottleCollection[1].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        tempMilkBottleCollection[1].GetComponent<Rigidbody2D>().angularVelocity = 0;

        tempMilkBottleCollection[2].transform.position = new Vector3(1.25f, 1.5f, 0);
        tempMilkBottleCollection[2].transform.rotation = Quaternion.Euler(0, 0, 0);
        tempMilkBottleCollection[2].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        tempMilkBottleCollection[2].GetComponent<Rigidbody2D>().angularVelocity = 0;

        ball.DeactiveateRb();
        ball.transform.position = new Vector3(-5.788f, -1.934f, 0f);
    }

    public void ReturnToGame()
    {
        SceneManager.LoadScene("FairGrounds");
    }
}
