using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGridView : MonoBehaviour
{
    public int numberOfRows, numberOfCol;
    public GameObject cellPrefab;
    public Transform SpawnPosition;

    public float horizontalGap, verticalGap, nextLineIndicator=0;
    



    // Start is called before the first frame update
    void Start()
    {
        Initializer();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initializer()
    {
        //CellView CellToSpawn = new CellView();
        TicTacToeGrid grid = new TicTacToeGrid(numberOfRows, numberOfCol);
        grid.cellCreated += CellCreator;
        grid.GridInitializer();
       
    }

    Vector3 PositionSetter()
    {
        if (nextLineIndicator < numberOfCol)
        {
            Debug.Log("1--------");
            Debug.Log(nextLineIndicator);
            nextLineIndicator++;
            return SpawnPosition.position = HorizontalShift();
        }
        else
        {
            Debug.Log("2--------");
            Debug.Log(nextLineIndicator);
            nextLineIndicator = 0;
            return SpawnPosition.position= VerticalShift();
        }
    }

    private Vector3 VerticalShift()
    {
        
        float incrementX = 2.5f;
        float incrementZ = SpawnPosition.position.y - 1.5f;
        return new Vector3(incrementX, SpawnPosition.position.y, incrementZ);
    }

    private Vector3 HorizontalShift()
    {
        float increment = SpawnPosition.position.x + 1.5f;
        return new Vector3(increment, SpawnPosition.position.y, SpawnPosition.position.z);
    }

    public void CellCreator(Cell cell)
    {
        //Debug.Log("ss");
        CellView cellView = Instantiate(cellPrefab, PositionSetter(), Quaternion.identity).GetComponent<CellView>();
        //SpawnPosition.position = cellView.transform.position;
      //  cellView.cell.SetIndex();
    }
}
