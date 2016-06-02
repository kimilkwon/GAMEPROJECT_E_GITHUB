using UnityEngine;
using System.Collections;

public class TileCollison : MonoBehaviour {
    Tile tile = null;
    UI_Center U_Center;
    public int item = 0;
    // Use this for initialization
    void Start () {
	
	}
	void Awake()
    {
        U_Center = GameObject.Find("SCRPIPTS").GetComponent<UI_Center>();
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
        U_Center.viewUp(item);
        Destroy(this.gameObject);
    }
}
