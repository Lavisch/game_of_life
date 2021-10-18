using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell : ProcessingLite.GP21
{
	float x, y; //Keep track of our position
	float size; //our size

	//Keep track if we are alive
	public bool alive = false;
	public bool aliveNext = false;

	//Constructor
	public GameCell(float x, float y, float size)
	{
		//Our X is equal to incoming X, and so forth
		//adjust our draw position so we are centered
		this.x = x + size / 2;
		this.y = y + size / 2;

		//diameter/radius draw size fix
		this.size = size / 2;
	}

	public void Draw()
	{
		//If we are alive, draw our dot.
		if (alive)
		{
			NoStroke();
			Fill(255);
			Circle(x, y, size);
		}
	}

	public void IsAliveNext(GameCell[,] cells, int x, int y)
	{
		int neighborsAlive = NeighborsAlive(cells, x, y);
        if (alive)
        {
            if (neighborsAlive < 2)
            {
				aliveNext = false;
            }
            else if (neighborsAlive < 4)
            {
				aliveNext = true;
            }
            else
            {
				aliveNext = false;
            }
        }
        else
        {
            if (neighborsAlive == 3)
            {
				aliveNext = true;
            }
            else
            {
				aliveNext = false;
            }
        }
	}

	public int NeighborsAlive(GameCell[,] cells, int x, int y)
    {
		int count = 0;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
				if ((i != 0) && (j != 0))
                {
					int checkY = y + i;
					int checkX = x + j;

					Debug.Log("checkX = " + checkX + ", checkY = " + checkY);

					if ((checkY < 0) || (y >= cells.GetLength(1)))
					{
						Debug.Log("bounds check failed checkY");
						continue;
					}

					if ((checkX < 0) || (x >= cells.GetLength(0)))
					{
						Debug.Log("bounds check failed checkX");
						continue;
					}

					if (cells[checkX, checkY].alive)
						count++;	
				}
			}
        }

		return count;
    }
}