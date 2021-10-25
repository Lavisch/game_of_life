using UnityEngine;

public class GameOfLife : ProcessingLite.GP21
{
	GameCell[,] cells;
	float cellSize = 0.5f;
	int numberOfColums;
	int numberOfRows;
	int spawnChancePercentage = 15;

	void Start()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 2;

		numberOfColums = (int)Mathf.Floor(Width / cellSize);
		numberOfRows = (int)Mathf.Floor(Height / cellSize);

		cells = new GameCell[numberOfColums, numberOfRows];

		for (int y = 0; y < numberOfRows; ++y)
		{
			for (int x = 0; x < numberOfColums; ++x)
			{
				cells[x, y] = new GameCell(x * cellSize, y * cellSize, cellSize);

				if (Random.Range(0, 100) < spawnChancePercentage)
				{
					cells[x, y].alive = true;
				}
			}
		}
		Debug.Log("cells size " + cells.GetLength(0) + " " + cells.GetLength(1));
	}

	void Update()
	{
		Background(0);

		for (int y = 0; y < numberOfRows; ++y)
		{
			for (int x = 0; x < numberOfColums; ++x)
			{
				cells[x, y].Draw();
			}
		}

        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
				cells[x, y].UpdateAliveNext(cells, x, y);
            }
        }

		for (int y = 0; y < numberOfRows; y++)
		{
			for (int x = 0; x < numberOfColums; x++)
			{
				GameCell cell = cells[x, y];
				cell.alive = cell.aliveNext;
			}
		}
	}
}