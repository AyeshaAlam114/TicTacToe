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

   public void SetStatus(Status CurrentStatus)
    {
        currentStatus = CurrentStatus;
        statusUpdate?. Invoke(currentStatus);
       
    }
    public void CellInteraction()
    {
        SetStatus(Status.win);
    }
}
