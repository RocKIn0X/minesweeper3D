using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
    public GameObject tilePrefabs;
    public int numberOfTile = 24;
    public float distanceBetweenTile = 2.0f;
    public int tilePerRow = 4;
	// Use this for initialization
	void Start () {
        createTile();
	}
	
    void createTile()
    {
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
            Instantiate(tilePrefabs, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z + zOffset), transform.rotation);
        }
    }
}
