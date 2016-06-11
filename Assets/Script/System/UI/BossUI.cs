using UnityEngine;
using System.Collections;

public class BossUI : MonoBehaviour {


    SpriteRenderer thisSprite, sprite;
  

    public void Change_UI_Boss()
    {



        thisSprite.sprite = sprite.sprite;

    }
   

    // Use this for initialization
    void Start()
    {

    }
    void Awake()
    {
        thisSprite = GetComponentInChildren<SpriteRenderer>();
        sprite = GameObject.Find("BossUI_com").GetComponent<SpriteRenderer>();

    }
    // Update is called once per frame
    void Update()
    {


    }

    void change()
    {

    }
}
