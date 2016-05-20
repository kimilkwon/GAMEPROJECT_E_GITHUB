using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public int hp = 5;
    public GameObject towerSpot = null;
    public GameObject [] tile_ =null;
     TileCollison tileColl = null;
    // Use this for initialization
    void Start () {

     
    }
	void Awake()
    {
        tileColl = GetComponentInParent<TileCollison>();
    }
	// Update is called once per frame
	void Update () {
	
	}



    public void TileBreakCheak()
    {
        if(hp>0)
        {
            Destroy(tile_[hp]);
            
        }
        else
        {

            tileColl.Die(); 
            Destroy(this.gameObject);
            
            Instantiate(towerSpot, new Vector3 (this.transform.position.x, this.transform.position.y-0.8f, this.transform.position.z), Quaternion.identity);
        }
    }
}
