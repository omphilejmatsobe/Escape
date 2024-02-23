using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpikesControl : MonoBehaviour
{
    [SerializeField]
    GameObject PointA, PointB;

    [SerializeField]
    float speed;

    bool trigger;


    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = PointA.transform.position;
        trigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;

        if (this.transform.position.y == PointA.transform.position.y)
        {
            trigger = false;
        }

        else if (this.transform.position.y == PointB.transform.position.y)
        {
            trigger = true;
        }

        if (trigger == false)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, PointB.transform.position, step);
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, PointA.transform.position, step);
        }
    }
}
