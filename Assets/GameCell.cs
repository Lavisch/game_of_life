using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell : ProcessingLite.GP21
{
	float x, y; //Keep track of our position
	float size; //our size

	//Keep track if we are alive
	public bool alive = false;

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
}