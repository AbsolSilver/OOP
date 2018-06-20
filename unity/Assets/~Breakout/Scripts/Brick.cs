using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    void OnCollisionEnter (Collision other)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().DestroyBrick();
        Destroy(gameObject);
    }

}
