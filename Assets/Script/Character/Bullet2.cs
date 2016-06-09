﻿using UnityEngine;
using System.Collections;

public class Bullet2 : MonoBehaviour {

    // Use this for initialization
    float speed = 10f;
    Vector3 dir;
    Vector3 mPosition;
    // Use this for initialization
    void Start()
    {
        mPosition = Input.mousePosition;
        set();
        Destroy(this.gameObject,0.5f);
    }

    void set()
    {
     
        Vector3 oPosition = transform.position; //게임 오브젝트 좌표 저장


        mPosition.z = oPosition.z - Camera.main.transform.position.z;

        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);
       
        dir = target - this.transform.position;
        dir.y -= 10;
        dir.Normalize();
    }
    void Update()
    {

      
        this.transform.Translate(dir * speed * Time.deltaTime);
    }
}