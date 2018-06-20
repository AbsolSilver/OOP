using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements : MonoBehaviour
{
    public bool IsMine;

    public Sprite[] emptyTiles;
    public Sprite[] mineTiles;

    void Start()
    {
        IsMine = Random.value < 0.15f;

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Grid.elements[x, y] = this;
    }

    public void loadTile (int adjacentCount)
    {
        if (IsMine)
        {
            GetComponent<SpriteRenderer>().sprite = mineTiles[0];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = emptyTiles[adjacentCount];
        }
    }

    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "spritesheet_30";
    }

    void OnMouseUpAsButton()
    {
        if (IsMine)
        {
            Grid.UncoverMines();
            GetComponent<SpriteRenderer>().sprite = mineTiles[1];
            print("You Died!");
        }
        else
        {
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            loadTile(Grid.adjacentMines(x, y));

            Grid.FFuncover(x, y, new bool[Grid.w, Grid.h]);
        }
    }
}
