using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    int Hp = 5;
    
    public GameObject [] tile_ =null; 
	// Use this for initialization
	void Start () {

     
    }
	void Awake()
    {
       
    }
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)//충돌 체크 함수
    {
        if (coll.gameObject.tag == "PLAYER")
        {
           Hp -= 1;
           TileBreakCheak();
        }
    }

    void TileBreakCheak()
    {
        if(Hp>0)
        {
            Destroy(tile_[Hp]);
            
        }
        else
        {
            
            
            Destroy(this.gameObject);
           
        }
    }
}
