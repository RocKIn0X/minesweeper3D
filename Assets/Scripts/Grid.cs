using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {
    public Tile tilePrefabs;
    public int numberOfTile = 24;
    public float distanceBetweenTile = 2.0f;
    public int tilePerRow = 4;
    public int numberOfMines;

    static Tile[] tilesAll;
    static List<Tile> tilesMined;
    static List<Tile> tilesUnmined;
	// Use this for initialization
	void Start () {
        createTile();
	}
	
    void createTile()
    {
        tilesAll = new Tile[numberOfTile];
        tilesMined = new List<Tile>();
        tilesUnmined = new List<Tile>();

        float xOffset = 0;
        float zOffset = 0;
        for(int createdTile = 0; createdTile < numberOfTile; createdTile++)
        {
            xOffset += distanceBetweenTile;
            if(createdTile % tilePerRow == 0)
            {
                zOffset += distanceBetweenTile;
                xOffset = 0;
            }
            Tile newTile = (Tile) Instantiate(tilePrefabs, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z + zOffset), transform.rotation);
            tilesAll[createdTile] = newTile;
        }
        AssignMines();
    }

    void AssignMines()
    {
        tilesUnmined.InsertRange(0, tilesAll);
        for (int minesAssigned = 0; minesAssigned < numberOfMines; minesAssigned++)
        {
            int rnd = (int)Random.Range(0, tilesUnmined.Count);
            Tile currentTile = tilesUnmined[rnd];

            tilesMined.Add(currentTile);
            tilesUnmined.RemoveAt(rnd);

            currentTile.GetComponent<Tile>();
            currentTile.isMined = true;
        }
    }
}
