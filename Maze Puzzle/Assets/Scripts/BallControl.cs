using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    float transY;
    Rigidbody2D rb;
    bool jumpEnabled, ballActivated;

    [SerializeField]
    GameObject Left, Right, Up, Down, puzzleObj, spawn;

    [SerializeField]
    UIManager manager;

    [SerializeField] 
    GameObject LeftParent, RightParent, UpParent, DownParent;

    Transform puzzle;

    // Start is called before the first frame update

    private void Awake()
    {
        puzzle = GameObject.FindWithTag("Puzzle").transform;
    }
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        jumpEnabled = false;
        ballActivated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            jumpEnabled = true;
            Debug.Log(collision.transform.eulerAngles.z);
        }

        if (collision.gameObject.tag == "Mushroom")
        {
            manager.MushroomCount("Add");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Spikes")
        {
            manager.LifeCount();
            GameObject.FindWithTag("Puzzle").transform.rotation = puzzle.transform.rotation;
            this.gameObject.transform.position = spawn.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
            jumpEnabled = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.M) && manager.Count > 0)
        {
            manager.MushroomCount("Minus");
            this.gameObject.transform.localScale = this.gameObject.transform.localScale * (1.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Walls") && (ballActivated == true))
        {
            Destroy(collision.gameObject);
            this.gameObject.transform.localScale = this.gameObject.transform.localScale * (0.75f);
            ballActivated = false;
        }


        if (collision.gameObject.tag == "Destination")
        {
            SceneManager.LoadScene(4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Left.transform.eulerAngles.z > -35) && (Left.transform.eulerAngles.z < 35))
        {
            LeftParent.SetActive(true);
            RightParent.SetActive(false);
            UpParent.SetActive(false);
            DownParent.SetActive(false);
        }
        else if ((Right.transform.eulerAngles.z > -35) && (Right.transform.eulerAngles.z < 35))
        {
            LeftParent.SetActive(false);
            RightParent.SetActive(true);
            UpParent.SetActive(false);
            DownParent.SetActive(false);
        }
        else if((Up.transform.eulerAngles.z > -35) && (Up.transform.eulerAngles.z < 35))
        {
            LeftParent.SetActive(false);
            RightParent.SetActive(false);
            UpParent.SetActive(true);
            DownParent.SetActive(false);
        }
        else if((Down.transform.eulerAngles.z > -35) && (Down.transform.eulerAngles.z < 35))
        {
            LeftParent.SetActive(false);
            RightParent.SetActive(false);
            UpParent.SetActive(false);
            DownParent.SetActive(true);
        }    


        if (Input.GetKey(KeyCode.Space) && jumpEnabled == true)
        { 
            rb.AddForce(new Vector2(0, 100f));
            Debug.Log("Jump Pressed...");
            ballActivated = true;
        }
    }
}
