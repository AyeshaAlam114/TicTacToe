using System;
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

    Cell.Status currentTurn = Cell.Status.cross;

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
                Cell tempCell=new Cell(row, col);
                cellsGrid[row].Add(tempCell);
                cellCreated?.Invoke(cellsGrid[row][col]);
                tempCell.cellStatusUpdate += GridCellStatus;
            }
        }
    }

    public void GridCellStatus(int row,int col)
    {
        if (cellsGrid[row][col].GetStatus() == Cell.Status.none)
        {
            cellsGrid[row][col].SetStatus(currentTurn);
            SetSingleElementAtIndex(row, col, (int)currentTurn);
            ChangeTurn(currentTurn);
            CheckWin(row,col);
        }
        
    }

    public void ChangeTurn(Cell.Status currentTurn)
    {
        switch (currentTurn)
        {
            case Cell.Status.cross:
                SwitchToCircle();
                break;
            case Cell.Status.circle:
                SwitchToCross();
                break;
        }
    }

    private void SwitchToCross()
    {
        currentTurn = Cell.Status.cross;
    }

    private void SwitchToCircle()
    {
        currentTurn= Cell.Status.circle;
    }

    public void CheckWin(int row,int col)
    {
        if (IsRowSame(row))
        {
            SetRowOfMatrixTo(row,(int)Cell.Status.win);
            cellsGrid[row][col].SetStatus(GetSingleElementOfIndex(row, col));
            PrintMatrix();
        }
    }

}
