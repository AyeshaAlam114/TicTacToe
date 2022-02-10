using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGrid : Matrix
{
    public List<List<Cell>> cellsGrid;

    public delegate void CellIsCreated(int row, int col);
    CellIsCreated cellCreated;

   public TicTacToeGrid(int numberOfRows,int numberOfColumns) : base(numberOfRows, numberOfColumns)
    {
        GridInitializer(numberOfRows, numberOfColumns);
    }

    public void GridInitializer(int numberOfRows, int numberOfColumns)
    {
        for (int row = 0; row < numberOfRows; row++)
        {
            cellsGrid.Add(new List<Cell>());
            for (int col = 0; col < numberOfColumns; col++)
            {
                cellsGrid[row].Add(new Cell());
                cellCreated?.Invoke(row,col);
            }
        }
    }


}
