using UnityEngine;

public class GameOfLife : ProcessingLite.GP21
{
	GameCell[,] cells;
	float cellSize = 0.25f;
	int numberOfColums;
	int numberOfRows;
	int spawnChancePercentage = 15;

	void Start()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 20;

		numberOfColums = (int)Mathf.Floor(Width / cellSize);
		numberOfRows = (int)Mathf.Floor(Height / cellSize);

		cells = new GameCell[numberOfColums, numberOfRows];

		for (int y = 0; y < numberOfRows; ++y)
		{
			for (int x = 0; x < numberOfColums; ++x)
			{
				cells[x, y] = new GameCell(x, y, cellSize);

				if (Random.Range(0, 100) < spawnChancePercentage)
					cells[x, y].alive = true;
			}
		}
	}

	void Update()
	{
		Draw();
		Control();

        foreach (GameCell cell in cells)
            UpdateAliveNext(cell);

        foreach (GameCell cell in cells)
			cell.alive = cell.aliveNext;
	}

    private void Draw()
    {
		Background(0);

        foreach (GameCell cell in cells)
			cell.Draw();
	}

    private void Control()
    {
		if (Input.GetKeyDown(KeyCode.D))
			Application.targetFrameRate += 1;

		if (Input.GetKeyDown(KeyCode.A))
			Application.targetFrameRate -= 1;
	}

	public void UpdateAliveNext(GameCell cell)
	{
		int neighborsAlive = NeighborsAlive(cell);

		cell.aliveNext = cell.alive;

		if (neighborsAlive == 3)
			cell.aliveNext = true;
		
		if (neighborsAlive < 2 || neighborsAlive > 3)
			cell.aliveNext = false;
	}

	public int NeighborsAlive(GameCell cell)
	{
		int count = 0;
		int x = cell.x;
		int y = cell.y;

		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				int checkY = y + i;
				int checkX = x + j;

                if ((checkX == x) && (checkY == y))
					continue;

                if ((checkY < 0) || (y >= numberOfRows - 1))
					continue;

				if ((checkX < 0) || (x >= numberOfColums - 1))
					continue;
				
				if (cells[checkX, checkY].alive)
					count++;
			}
		}
		return count;
	}
}