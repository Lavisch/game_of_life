using UnityEngine;

public class GameOfLife : ProcessingLite.GP21
{
	GameCell[] cells;
	float cellSize = 0.8f;
	int numberOfColums;
	int numberOfRows;
	int spawnChancePercentage = 15;

	void Start()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 20;

		numberOfColums = (int)Mathf.Floor(Width / cellSize);
		numberOfRows = (int)Mathf.Floor(Height / cellSize);

		cells = new GameCell[numberOfColums * numberOfRows];

        for (int i = 0; i < cells.Length; i++)
        {
			int x = i % numberOfColums;
			int y = i / numberOfColums;
			cells[i] = new GameCell(x, y, cellSize);
			if (Random.Range(0, 100) < spawnChancePercentage)
				cells[i].alive = true;

		}
		Debug.Log(numberOfColums + " " + numberOfRows);
		Debug.Log(cells.Length);
	}

	void Update()
	{
		Background(0);
		Control();
        for (int i = 0; i < cells.Length; i++)
        {
			cells[i].Draw();
            UpdateAliveNext(i);
        }

        foreach (GameCell cell in cells)
			cell.alive = cell.aliveNext;
	}

    private void Control()
    {
		if (Input.GetKeyDown(KeyCode.D))
			Application.targetFrameRate += 1;

		if (Input.GetKeyDown(KeyCode.A))
			Application.targetFrameRate -= 1;
	}

	public void UpdateAliveNext(int currentIndex)
	{
		int neighborsAlive = NeighborsAlive(currentIndex);

		cells[currentIndex].aliveNext = cells[currentIndex].alive;

		if (neighborsAlive == 3)
			cells[currentIndex].aliveNext = true;
		
		if (neighborsAlive < 2 || neighborsAlive > 3)
			cells[currentIndex].aliveNext = false;
	}

	public int NeighborsAlive(int currentIndex)
	{
		int count = 0;

		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				int checkIndex = currentIndex + numberOfColums * i + j;

                if (checkIndex == currentIndex)
					continue;

				if (checkIndex < 0 || checkIndex >= cells.Length)
					continue;

				if (cells[checkIndex].alive)
					count++;
			}
		}
		return count;
	}
}