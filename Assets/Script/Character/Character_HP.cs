using UnityEngine;
using System.Collections;

public class Character_HP : MonoBehaviour {
    public GameObject[] character_hp = null;
    int hp = 3;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider coll)//충돌 체크 함수
    {

        if (coll.gameObject.tag == "ZOMBI")
        {
            hp -= 1;
            HpCheck();
             

        }
        if (coll.gameObject.tag == "BOSS_BULLET")
        {

            hp -= 1;
            HpCheck();
            Destroy(coll.gameObject);
        }
    }
    public void HpCheck()
    {
        if (hp > 0)
        {
            Destroy(character_hp[hp]);

        }
        else
        {
            AutoFade.LoadLevel("GameOver", 1, 1, Color.black);

        }
    }
}
