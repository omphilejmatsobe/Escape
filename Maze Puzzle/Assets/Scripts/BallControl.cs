using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    float transY;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Puzzle")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, 7f));
                Debug.Log("Jump Pressed...");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
