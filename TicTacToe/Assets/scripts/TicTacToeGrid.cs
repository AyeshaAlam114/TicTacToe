using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGrid : Matrix
{
    public List<List<Cell>> cellsGrid=new List<List<Cell>>();

    public delegate void CellIsCreated(Cell cell);
    public CellIsCreated cellCreated;
    int numberOfRows;
    int numberOfColumns;

   public TicTacToeGrid(int NumberOfRows,int NumberOfColumns) : base(NumberOfRows, NumberOfColumns)
    {
        //GridInitializer(numberOfRows, numberOfColumns);
        numberOfRows = NumberOfRows;
        numberOfColumns = NumberOfColumns;
    }

    public void GridInitializer()
    {
        for (int row = 0; row < numberOfRows; row++)
        {
            cellsGrid.Add(new List<Cell>());
            for (int col = 0; col < numberOfColumns; col++)
            {
                cellsGrid[row].Add(new Cell());
                cellCreated?.Invoke(cellsGrid[row][col]);
            }
        }
    }


}
