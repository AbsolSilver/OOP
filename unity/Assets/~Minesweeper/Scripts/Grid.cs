using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public static int w = 11;
    public static int h = 14;
    public static Elements[,] elements = new Elements[w, h];

    public static void UncoverMines()
    {
        foreach (Elements elem in elements)
        {
            if (elem.IsMine)
            {
                elem.loadTile(0);
            }
        }
    }

    public static bool mineAt(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            return elements[x, y].IsMine;
        }
        return false;
    }

    public static int adjacentMines(int x, int y)
    {
        int count = 0;

        if (mineAt(x, y + 1))
        {
            ++count;
        }

        if (mineAt(x + 1, y + 1))
        {
            ++count;
        }

        if (mineAt(x + 1, y))
        {
            ++count;
        }

        if (mineAt(x + 1, y - 1))
        {
            ++count;
        }

        if (mineAt(x, y - 1))
        {
            ++count;
        }

        if (mineAt(x - 1, y - 1))
        {
            ++count;
        }

        if (mineAt(x - 1, y))
        {
            ++count;
        }

        if (mineAt(x - 1, y + 1))
        {
            ++count;
        }

        return count;
    }

    public static void FFuncover(int x, int y, bool[,] visited)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            if (visited[x, y])
            {
                return;
            }

            elements[x, y].loadTile(adjacentMines(x, y));

            if(adjacentMines(x, y) > 0)
            {
                return;
            }

            visited[x, y] = true;

            FFuncover(x - 1, y, visited);
            FFuncover(x + 1, y, visited);
            FFuncover(x, y - 1, visited);
            FFuncover(x, y + 1, visited);
        }
    }
}


