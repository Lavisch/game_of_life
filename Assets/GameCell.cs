using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell : ProcessingLite.GP21
{
	float x, y;
	float size;

	public bool alive = false;
	public bool aliveNext = false;

	public GameCell(float x, float y, float size)
	{
		this.x = x + size / 2;
		this.y = y + size / 2;

		this.size = size / 2;
	}

	public void Draw()
	{
		if (alive)
		{
			Fill(255);
			Circle(x, y, size);
		}
	}

	public void UpdateAliveNext(GameCell[,] cells, int x, int y)
	{
		int neighborsAlive = NeighborsAlive(cells, x, y);
        if (alive)
        {
            if (neighborsAlive < 2)
				aliveNext = false;

            else if (neighborsAlive < 4)
				aliveNext = true;

            else
				aliveNext = false;
        }
        else
        {
            if (neighborsAlive == 3)
				aliveNext = true;

            else
				aliveNext = false;
        }
		Debug.Log(x + " " + y + ", alive = " + alive + ", neighborsAlive = " + neighborsAlive + ", aliveNext = " + aliveNext);
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

					if ((checkY < 0) || (y >= cells.GetLength(1) - 1))
					{
						//Debug.Log("1st check: checkX = " + checkX + ", checkY = " + checkY);
						continue;
					}

					if ((checkX < 0) || (x >= cells.GetLength(0) - 1))
					{
						//Debug.Log("2nd check: checkX = " + checkX + ", checkY = " + checkY);
						continue;
					}
					//Debug.Log("Pass checks, checkX = " + checkX + ", checkY = " + checkY);
					if (cells[checkX, checkY].alive)
						count++;	
				}
			}
        }
		return count;
    }
}