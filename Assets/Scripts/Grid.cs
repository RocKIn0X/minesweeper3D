using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
    public Tile tilePrefabs;
    public int numberOfTile = 24;
    public float distanceBetweenTile = 2.0f;
    public int tilePerRow = 4;
    public int numberOfMines;

    static Tile[] tilesAll;
    static ArrayList tilesMined;
    static ArrayList tilesUnmined;
	// Use this for initialization
	void Start () {
        createTile();
	}
	
    void createTile()
    {
        tilesAll = new Tile[numberOfTile];
        tilesMined = new ArrayList();
        tilesUnmined = new ArrayList();

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
        tilesUnmined = tilesAll;

        for(int minesAssigned = 0; minesAssigned < numberOfMines; minesAssigned++)
        {
            
        }
    }
}
