using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
    public GameObject tirePrefabs;
    public int numberOfTire = 24;
    public float distanceBetweenTire = 2.0f;
    public int tilePerRow = 4;
	// Use this for initialization
	void Start () {
        createTire();
	}
	
    void createTire()
    {

    }
}
