using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bricks = 32;
    public GameObject bricksPrefab;
    
    // Use this for initialization
    void Start()
    {
        SetUp();
    }

    public void SetUp()
    {
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyBrick()
    {
        bricks--;
    }
}
