using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzleControl : MonoBehaviour
{
    GameObject Puzzle;
    float Hor, Ver, rotation;

    // Start is called before the first frame update
    void Start()
    {
        Puzzle = GameObject.FindWithTag("Puzzle");
    }

    // Update is called once per frame
    void Update()
    {
        Hor = Input.GetAxis("Horizontal");
        Ver = Input.GetAxis("Vertical");

        rotation += (Hor/ 7);

        transform.eulerAngles = new Vector3(0, 0, rotation);
    }
}
