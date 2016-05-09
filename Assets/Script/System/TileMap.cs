using UnityEngine;
using System.Collections;

public class TileMap : MonoBehaviour {
    public GameObject Tile_base;
    float i,j;
    // Use this for initialization
    void Awake () {
	
        for(i=-4.5f;i<5.5f;i++)
        {
            for (j = 0f; j >-4.5f; j--)
            { 
                Instantiate(Tile_base, new Vector3(i, j,0), Quaternion.identity);
             }
        }
	}
	
	// Update is called once per frame
	void Update () {
       
    }
}
