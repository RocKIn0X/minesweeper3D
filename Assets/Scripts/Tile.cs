using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
    public bool isMined = false;
    public TextMesh displayText;
    public Material materialIdle;
    public Material materialLightup;
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

    void Start()
    {
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
    }

    void OnMouseOver()
    {
        GetComponent<Renderer>().material = materialLightup;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material = materialIdle;
    }

    bool inBounds(Tile[] inputList, int targetID)
    {
        throw new NotImplementedException();
        if (targetID < 0 || targetID >= inputList.Length)
            return false;
        else
            return true;
    }
}
