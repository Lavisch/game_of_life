using UnityEngine;

public class GameOfLife : ProcessingLite.GP21
{
	GameCell[,] cells; //Our game grid matrix
	float cellSize = 0.5f; //Size of our cells
	int numberOfColums;
	int numberOfRows;
	int spawnChancePercentage = 15;

	void Start()
	{
		//Lower framerate makes it easier to test and see whats happening.
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 4;

		//Calculate our grid depending on size and cellSize
		numberOfColums = (int)Mathf.Floor(Width / cellSize);
		numberOfRows = (int)Mathf.Floor(Height / cellSize);

		//Initiate our matrix array
		cells = new GameCell[numberOfColums, numberOfRows];

		//Create all objects

		//For each row
		for (int y = 0; y < numberOfRows; ++y)
		{
			//for each column in each row
			for (int x = 0; x < numberOfColums; ++x)
			{
				//Create our game cell objects, multiply by cellSize for correct world placement
				cells[x, y] = new GameCell(x * cellSize, y * cellSize, cellSize);

				//Random check to see if it should be alive
				if (Random.Range(0, 100) < spawnChancePercentage)
				{
					cells[x, y].alive = true;
				}
			}
		}
	}

	void Update()
	{
		//Clear screen
		Background(0);

		//TODO: Calculate next generation
		GameCell[,] cellsBuffer;


		//TODO: update buffer

		//Draw all cells.
		for (int y = 0; y < numberOfRows; ++y)
		{
			for (int x = 0; x < numberOfColums; ++x)
			{
				//Draw current cell
				cells[x, y].Draw();
			}
		}
	}
}