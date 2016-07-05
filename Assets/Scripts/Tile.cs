using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Tile : MonoBehaviour {
    public bool isMined = false;
    public TextMesh displayText;
    public GameObject displayFlag;

    public Material materialIdle;
    public Material materialLightup;
    public Material materialUncovered;

    public int ID;
    public int tilesPerRow;

    public Tile tileUpper;
    public Tile tileLower;
    public Tile tileLeft;
    public Tile tileRight;

    public Tile tileUpperRight;
    public Tile tileUpperLeft;
    public Tile tileLowerRight;
    public Tile tileLowerLeft;

    public List<Tile> adjacentTiles = new List<Tile>();

    public int adjacentMines = 0;

    public String state = "Idle"; //Unity always changes your first letter to Capital letter

    void Start()
    {
        gameObject.name = "Tile" + ID.ToString();

        if (inBounds(Grid.tilesAll, ID + tilesPerRow))
            tileUpper = Grid.tilesAll[ID + tilesPerRow];
        if (inBounds(Grid.tilesAll, ID - tilesPerRow))
            tileLower = Grid.tilesAll[ID - tilesPerRow];
        if (inBounds(Grid.tilesAll, ID - 1) && ID % tilesPerRow != 0)
            tileLeft = Grid.tilesAll[ID - 1];
        if (inBounds(Grid.tilesAll, ID + 1) && (ID + 1) % tilesPerRow != 0)
            tileRight = Grid.tilesAll[ID + 1];

        if (inBounds(Grid.tilesAll, ID + tilesPerRow + 1) && (ID + 1) % tilesPerRow != 0)
            tileUpperRight = Grid.tilesAll[ID + tilesPerRow + 1];
        if (inBounds(Grid.tilesAll, ID + tilesPerRow - 1) && ID % tilesPerRow != 0)
            tileUpperLeft = Grid.tilesAll[ID + tilesPerRow - 1];
        if (inBounds(Grid.tilesAll, ID - tilesPerRow - 1) && (ID + 1) % tilesPerRow != 0)
            tileLowerRight = Grid.tilesAll[ID - tilesPerRow - 1];
        if (inBounds(Grid.tilesAll, ID - tilesPerRow + 1) && ID % tilesPerRow != 0)
            tileLowerLeft = Grid.tilesAll[ID - tilesPerRow + 1];

        if (tileUpper)
            adjacentTiles.Add(tileUpper);
        if (tileLower)
            adjacentTiles.Add(tileLower);
        if (tileLeft)
            adjacentTiles.Add(tileLeft);
        if (tileRight)
            adjacentTiles.Add(tileRight);
        if (tileUpperRight)
            adjacentTiles.Add(tileUpperRight);
        if (tileUpperLeft)
            adjacentTiles.Add(tileUpperLeft);
        if (tileLowerRight)
            adjacentTiles.Add(tileLowerRight);
        if (tileLowerLeft)
            adjacentTiles.Add(tileLowerLeft);

        CountMines();

        displayText.GetComponent<Renderer>().enabled = false;
        displayFlag.GetComponent<Renderer>().enabled = false;

    }

    void OnMouseOver()
    {
        GetComponent<Renderer>().material = materialLightup;
        if (state == "Idle")
        {
            if (Input.GetMouseButtonDown(0))
            {
                UncoverTile();
            }

            if (Input.GetMouseButtonDown(1))
            {
                SetFlag();
            }
        }
        else if (state == "Flagged")
        {
            if (Input.GetMouseButtonDown(1))
            {
                SetFlag();
            }
        }
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material = materialIdle;
    }

    bool inBounds(Tile[] inputList, int targetID)
    {
        if (targetID < 0 || targetID >= inputList.Length)
            return false;
        else
            return true;
    }

    void CountMines()
    {
        adjacentMines = 0;

        foreach(Tile currentTile in adjacentTiles) //arrayList can't use in foreach
        {
            if (currentTile.isMined)
                adjacentMines += 1;
        }

        displayText.text = adjacentMines.ToString();

        if (adjacentMines <= 0)
            displayText.text = "";
    }

    void SetFlag()
    {
        if(state == "Idle")
        {
            state = "Flagged";
            displayFlag.GetComponent<Renderer>().enabled = true;
        }

        else if(state == "Flagged")
        {
            state = "Idle";
            displayFlag.GetComponent<Renderer>().enabled = false;
        }
    }

    void UncoverTile()
    {
        if (!isMined)
        {
            state = "uncovered";
            displayText.GetComponent<Renderer>().enabled = true;
            materialIdle = materialUncovered;
        }
        //else
            //Explode();
    }
}
