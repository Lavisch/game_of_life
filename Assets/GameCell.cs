using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell : ProcessingLite.GP21
{
	float size;
	int x, y;

	public bool alive;
	public bool aliveNext;

	public GameCell(int x, int y, float size)
	{
		this.x = x;
		this.y = y;
		this.size = size / 2;
	}

	public void Draw()
	{
		if (alive)
		{
			NoStroke();
			Fill(255);
			Circle(x * size * 2 + size, y * size * 2 +  size, size);
		}
	}
}