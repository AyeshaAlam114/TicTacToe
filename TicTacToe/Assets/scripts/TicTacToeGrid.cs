using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGrid : Matrix
{
    public List<List<Cell>> cellsGrid = new List<List<Cell>>();

    public delegate void CellIsCreated(Cell cell);
    public CellIsCreated cellCreated;
    int numberOfRows;
    int numberOfColumns;
    bool winCheck;

    Cell.Status currentTurn = Cell.Status.cross;

    public TicTacToeGrid(int NumberOfRows, int NumberOfColumns) : base(NumberOfRows, NumberOfColumns)
    {
        //GridInitializer(numberOfRows, numberOfColumns);
        numberOfRows = NumberOfRows;
        numberOfColumns = NumberOfColumns;
        winCheck = false;
    }

    public void GridInitializer()
    {
        for (int row = 0; row < numberOfRows; row++)
        {
            cellsGrid.Add(new List<Cell>());
            for (int col = 0; col < numberOfColumns; col++)
            {
                Cell tempCell = new Cell(row, col);
                cellsGrid[row].Add(tempCell);
                cellCreated?.Invoke(cellsGrid[row][col]);
                tempCell.cellStatusUpdate += GridCellStatus;
            }
        }
    }

    public void GridCellStatus(int row, int col)
    {
        if (!winCheck)
        {
            if (cellsGrid[row][col].GetStatus() == Cell.Status.none)
            {
                //cellsGrid[row][col].SetStatus(currentTurn);
                SetSingleElementAtIndex(row, col, (int)currentTurn);
                // ChangeCellDisplay(row, col);
                ChangeTurn(currentTurn);
                CheckWin(row, col);
                UpdateGridDisplay();
            }
            if (CheckDraw())
            {
                Debug.Log("Game is draw");
                return;
            }
        }
       

    }

    void UpdateGridDisplay()
    {
       
        for (int row = 0; row < cellsGrid.Count; row++)
        {
            for (int col = 0; col < cellsGrid[row].Count; col++)
            {
                cellsGrid[row][col].SetStatus(matrixHolder[row][col]);
            }
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
        currentTurn = Cell.Status.circle;
    }

    public bool CheckWin(int row, int col)
    {
        if (IsRowSame(row))
        {
            SetRowOfMatrixTo(row, (int)Cell.Status.win);
            //cellsGrid[row][col].SetStatus(GetSingleElementOfIndex(row, col));
           // PrintMatrix();
            return winCheck = true;
        }
        if (IsColumnSame(col))
        {
            SetColumnOfMatrixTo(col, (int)Cell.Status.win);
            //cellsGrid[row][col].SetStatus(GetSingleElementOfIndex(row, col));
            //PrintMatrix();
            return winCheck = true;
        }
        if (IsPrimaryDiagnalSame() && GetPrimaryDiagnal()[0] != 0)
        {
            SetPrimaryDiagnalTo((int)Cell.Status.win);
            //cellsGrid[row][col].SetStatus(GetSingleElementOfIndex(row, col));
            //PrintMatrix();
            return winCheck = true;
        }
        if (IsSecondaryDiagnalSame() && GetSecondaryDiagnal()[0]!=0)
        {
            SetSecondaryDiagnalTo((int)Cell.Status.win);
            //cellsGrid[row][col].SetStatus(GetSingleElementOfIndex(row, col));
            //PrintMatrix();
            return winCheck = true;
        }

        return winCheck = false;
       
    }

    public bool CheckDraw()
    {
        bool turnComplete = false;

        for (int row = 0; row < cellsGrid.Count; row++)
        {
            //for (int col = 0; col < cellsGrid[row].Count; col++)
            //{
            //cellsGrid[row][col].SetStatus(matrixHolder[row][col]);
            if (!matrixHolder[row].Contains(0))
                turnComplete = true;
            else
                turnComplete = false;
            //}
        }

        return turnComplete;
    }

}
