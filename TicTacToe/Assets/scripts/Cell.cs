using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    int rowIndex, colIndex;
    public enum Status { none,circle,cross,loose,win};
    public Status currentStatus;

    public delegate void StatusUpdate(Status currentStatus);
    public StatusUpdate statusUpdate;

    public delegate void CellStatusUpdate(int row,int col);
    public CellStatusUpdate cellStatusUpdate;


    public Cell(int row,int col)
    {
        rowIndex = row;
        colIndex = col;
    }
   public void SetStatus(Status CurrentStatus)
    {
        Debug.Log("1");
        currentStatus = CurrentStatus;
        statusUpdate?. Invoke(currentStatus);
       
    }
    public void SetStatus(int CurrentStatus)
    {
       // Debug.Log("1");
        currentStatus = (Status)CurrentStatus;
        statusUpdate?.Invoke(currentStatus);

    }
    public Status GetStatus()
    {
       return  currentStatus;
    }
    //public void SetIndex(int row,int col)
    //{

    //}
    public void CellInteraction()
    {
       // Debug.Log("cell is not set");
       // SetStatus(Status.win);
        cellStatusUpdate?.Invoke(rowIndex,colIndex);

    }
}
