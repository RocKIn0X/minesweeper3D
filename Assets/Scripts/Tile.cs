using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
    public bool isMined = false;
    public TextMesh displayText;
    public Material materialIdle;
    public Material materialLightup;
    public int ID;
    public int tilesPerRow;

    void OnMouseOver()
    {
        GetComponent<Renderer>().material = materialLightup;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material = materialIdle;
    }
}
