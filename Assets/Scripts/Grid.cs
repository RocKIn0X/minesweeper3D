using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Grid : MonoBehaviour {
    public Tile tilePrefabs;
    public int numberOfTile = 24;
    public float distanceBetweenTile = 2.0f;
    public int tilePerRow = 4;
    public int numberOfMines;

    public static Tile[] tilesAll; //The default protection level for javascript is public, but it's private in c#
    public static List<Tile> tilesMined;
    public static List<Tile> tilesUnmined;

    public static string state = "inGame";

    public static int minesMarkedCorrectly = 0;
    public static int tilesUncovered = 0;
    public static int minesRemaining = 0;

	void Start () {
        createTile();

        minesRemaining = numberOfMines;
        minesMarkedCorrectly = 0;
        tilesUncovered = 0;

        state = "inGame";
	}

    void Update()
    {
        if(state == "inGame")
        {
            if ((minesRemaining == 0 && minesMarkedCorrectly == numberOfMines) || (tilesUncovered == numberOfTile - numberOfMines))
                FinishGame();
        }
    }

    void FinishGame()
    {
        state = "gameWon";

        //Uncovers remaining fields if all nodes have been placed
        foreach (Tile currentTile in tilesAll)
            if (currentTile.state == "Idle" && !currentTile.isMined)
                currentTile.UncoverTileExternal();

        //Mark remaining mines if all nodes except the mines have been uncovered
        foreach (Tile currenTile in tilesMined)
            if (currenTile.state != "Flagged")
                currenTile.SetFlag();
    }

    void OnGUI()
    {
        if(state == "inGame")
        {
            GUI.Box(new Rect(10, 10, 200, 50), "Mines left: " + minesRemaining);
        }
        else if(state == "gameOver")
        {
            GUI.Box(new Rect(10, 10, 200, 50), "You lose!!!");

            if (GUI.Button(new Rect(10, 70, 200, 50), "Restart"))
                Restart();
        }
        else if(state == "gameWon")
        {
            GUI.Box(new Rect(10, 10, 200, 50), "Awesome! You win.");

            if (GUI.Button(new Rect(10, 70, 200, 50), "Restart"))
                Restart();
        }
    }

    public void Restart()
    {
        state = "loading";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

            newTile.ID = createdTile;
            newTile.tilesPerRow = tilePerRow;

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
