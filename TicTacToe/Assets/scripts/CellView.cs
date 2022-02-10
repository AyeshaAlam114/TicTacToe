using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView :MonoBehaviour
{
    public GameObject[] possibleStatus;
    public Cell cell;
    // Start is called before the first frame update
    private void OnEnable()  
    {
        cell = new Cell();
        SetStatus(Cell.Status.none);
       // DisableAllStatus();
        CellInitializer();
    }
    
    public void CellInitializer()
    {
        cell.statusUpdate += SetStatus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStatus(Cell.Status currentStatus)
    {
        DisableAllStatus();
        EnableCurrentStatus((int)currentStatus);
    }

    private void EnableCurrentStatus(int indexOfStatus)
    {
        possibleStatus[indexOfStatus].SetActive(true);
    }

    private void DisableAllStatus()
    {
        foreach (GameObject status in possibleStatus)
            status.SetActive(false);
    }

    private void OnMouseDown()
    {
        cell.CellInteraction();
    }
    private void OnDestroy()
    {
        cell.statusUpdate -= SetStatus;
    }
}
