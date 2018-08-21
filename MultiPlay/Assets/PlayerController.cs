using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speedMove = 5f;
    [SerializeField]
    float speedRotate = 60f;

    public Rigidbody tank;


    void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");

        if ( vert  != 0)
        {
            transform.Translate(Vector3.right *vert * speedMove * Time.deltaTime);
        }

        if (horiz != 0)
        {
            transform.Rotate(Vector3.up * horiz * speedRotate * Time.deltaTime);
        }

    }
}