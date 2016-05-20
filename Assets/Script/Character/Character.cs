﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    // Use this for initialization
    float leftTime = 0.5f;
    int speed = 5; //스피드 
    Monster monster;
    Animator animator;
    public GameObject Pick;
    public GameObject Bullet;

    bool ch_pick = false;
    bool ch_move = false;
    bool ch_move_ani = false;
    bool ch_movePick = false;
    bool ch_moveShoot = false;
    bool ch_Shoot = false;
    bool ch_moveAim = false;
    bool ch_Aim = false;
    int mode = 1;

    



    void  Awake()
    {
        animator = GetComponent<Animator>();
       
    }

    void Start()
    {
        
        monster = GameObject.Find("monster").GetComponent<Monster>();
    }
   

    void Update()
    {
        
        C_Move();
        
        Ch_KeyInput();
       //Rotation();
        if ( ch_pick == false&&ch_move == false&&ch_move_ani == false&&ch_movePick == false&& ch_moveShoot == false&& ch_Aim == false&& ch_Shoot==false&& ch_moveAim==false)
        {
            animator.Play("Player");
        }
    }


    void C_Move()
    {
        if (ch_movePick == false && ch_Aim ==false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                ch_move = true;
                if (ch_move_ani == false)
                {
                    StartCoroutine(C_MoveAni());
                }
                
             

            }
            if (Input.GetKey(KeyCode.D))
            {
                ch_move = true;
                if (ch_move_ani == false)
                {
                    StartCoroutine(C_MoveAni());
                }


            }
            if (Input.GetKey(KeyCode.W))
            {
                ch_move = true;
                if (ch_move_ani == false)
                {
                    StartCoroutine(C_MoveAni());
                }

               

            }
            if (Input.GetKey(KeyCode.S))
            {
                ch_move = true;
                if (ch_move_ani == false)
                {
                    StartCoroutine(C_MoveAni());
                }


            }
            else
            {
                ch_move = false;

            }
        }
        else if (ch_movePick == true||ch_Aim==true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                ch_move = true;
                
            }
            if (Input.GetKey(KeyCode.W))
            {
                ch_move = true;

               
            }
            if (Input.GetKey(KeyCode.S))
            {
                ch_move = true;
                
            }
            if (Input.GetKey(KeyCode.D))
            {
                ch_move = true;
               
            }
        }
      
    }
    IEnumerator C_MoveAni()
    {
        ch_move_ani = true;
        animator.Play("PlayerMove");
        yield return new WaitForSeconds(0.48f);
        
        ch_move_ani = false;
    }
    


void Ch_KeyInput()
    {
        if (Input.GetMouseButton(0)&& ch_movePick==false&& ch_Aim == false&&ch_Shoot == false&& ch_moveShoot ==false)
        {
            
            StartCoroutine(Pickax());
            StartCoroutine(Pickax_Hit());
        }
        if (Input.GetMouseButton(1) && ch_movePick == false)
        {
           
            if(ch_move==true)
            {
                StartCoroutine(AimMove());
            }
            else if(ch_move== false)
            {

                StartCoroutine(Aim());
            }
            if (ch_move == true && Input.GetMouseButtonDown(0))
            {

                StartCoroutine(ShootMove());
            }
            if (Input.GetMouseButtonDown(0)&&ch_move!=true)
            {
                ch_Aim = false;
                StartCoroutine(Shoot());
            }
        
           
        }
   
        if (Input.GetMouseButtonUp(1))
        {
           
            ch_Aim = false;
        }
    }
    IEnumerator Pickax()
    {
        
        ch_movePick = true;
        animator.Play("PlayerMovePickax");
        yield return new WaitForSeconds(1.0f);
        ch_movePick = false;
        animator.Play("Player");
        yield return null;
    }
    IEnumerator Pickax_Hit()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(Pick, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(Pick, this.transform.position, Quaternion.identity);
        yield return null;
    }
    IEnumerator Shoot()
    {
        
        ch_Shoot = true;
        animator.Play("PlayerShoot");
        // Instantiate(Bullet, new Vector3(this.transform.position.x + 0.3f, this.transform.position.y + 0.5f, this.transform.position.z), Quaternion.identity);
        Instantiate(Bullet, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        Instantiate(Bullet, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        Instantiate(Bullet, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.0f);
        ch_Shoot = false;
        
        yield return null;
    }
    IEnumerator ShootMove()
    {

        ch_moveShoot = true;
        animator.Play("PlayerShootMove");
        Instantiate(Bullet, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        Instantiate(Bullet, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        Instantiate(Bullet, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.0f);
        ch_moveShoot = false;
        
        yield return null;
    }
    IEnumerator Aim()
    {

        ch_Aim = true;
        animator.Play("PlayerAim");
        yield return new WaitForSeconds(0.65f);
        
        yield return null;
    }
    IEnumerator AimMove()
    {

        ch_moveAim = true;
        animator.Play("PlayerAimMove");
        yield return new WaitForSeconds(1.0f);
        ch_moveAim = false;
        
        ch_move = false;

        yield return null;
    }

    void Rotation()
    {

        Vector3 mPosition = Input.mousePosition; //마우스 좌표 저장
        Vector3 oPosition = transform.position; //게임 오브젝트 좌표 저장


        mPosition.z = oPosition.z - Camera.main.transform.position.z;

        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);


        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;


        float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotateDegree - 10f);
    }


}

