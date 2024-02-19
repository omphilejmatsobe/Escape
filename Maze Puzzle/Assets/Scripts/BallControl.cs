using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    float transY;
    Rigidbody2D rb;
    bool jumpEnabled;

    [SerializeField]
    GameObject Left, Right, Up, Down;

    [SerializeField] 
    GameObject LeftParent, RightParent, UpParent, DownParent;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        jumpEnabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            jumpEnabled = true;
            Debug.Log(collision.transform.eulerAngles.z);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
            jumpEnabled = false;
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
        }   
    }
}
