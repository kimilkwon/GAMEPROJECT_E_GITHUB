using UnityEngine;
using System.Collections;

public class TileCollison : MonoBehaviour {
    Tile tile = null;

    // Use this for initialization
    void Start () {
	
	}
	void Awake()
    {

        tile = GetComponentInChildren<Tile>();
    }
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider coll)//충돌 체크 함수
    {
        if (coll.gameObject.tag == "PICK")
        {
            tile.hp -= 1;
            tile.TileBreakCheak();
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "BULLET")
        {

            Destroy(coll.gameObject);
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
