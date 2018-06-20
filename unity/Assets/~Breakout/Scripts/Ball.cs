using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 600f;

    private Rigidbody rigid;

    private bool ballInPlay;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rigid.isKinematic = false;
            rigid.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
    }
}
