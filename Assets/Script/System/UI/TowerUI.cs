using UnityEngine;
using System.Collections;

public class TowerUI : MonoBehaviour {


    SpriteRenderer thisSprite,sprite,sprite2;
    public bool Change = true;

    public void Change_UI_Tower()
    {
        


            thisSprite.sprite = sprite.sprite;
        
    }
    public void Change_UI_Basic()
    {
        thisSprite.sprite = sprite2.sprite;

    }

    // Use this for initialization
    void Start()
    {
       
    }
    void Awake()
    {
         thisSprite = GetComponentInChildren<SpriteRenderer>();
        sprite = GameObject.Find("TowerUI_com").GetComponent<SpriteRenderer>();
        sprite2 = GameObject.Find("TowerUI_basic").GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {


    }

    void change()
    {
       
    }
}
