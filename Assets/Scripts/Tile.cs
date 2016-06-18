using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
    public bool isMined = false;
    public Material materialIdle;
    public Material materialLightup;

    void OnMouseOver()
    {
        GetComponent<Renderer>().material = materialLightup;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material = materialIdle;
    }
}
