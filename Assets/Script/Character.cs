using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    // Use this for initialization
    float leftTime = 0.5f;
    int speed = 5; //스피드 
    Monster monster;
    Animator animator;
    public GameObject Pick;

    bool ch_pick = false;
    bool ch_move = false;
    bool ch_move_ani = false;
    bool ch_movePick = false;
    bool ch_moveAttack = false;
    float rotateDegree = 0.0f;

    void TimeCheck()
    {
        if (leftTime > 0)
        {
            leftTime -= Time.deltaTime;
            if (leftTime < 0)
            {
                leftTime = 0.5f;
                monster.MonsterTargetPoint(this.transform.position);
            }
          

        }
    }

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
        TimeCheck();
        Ch_KeyInput();
        C_rotation();
        if ( ch_pick == false&&ch_move == false&&ch_move_ani == false&&ch_movePick == false&&ch_moveAttack == false)
        {
            animator.Play("Player");
        }
    }


    void C_Move()
    {
        if (ch_movePick == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                ch_move = true;
                if (ch_move_ani == false)
                {
                    StartCoroutine(C_MoveAni());
                }
                
                transform.Translate(Vector2.left * speed * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.D))
            {
                ch_move = true;
                if (ch_move_ani == false)
                {
                    StartCoroutine(C_MoveAni());
                }

                transform.Translate(Vector2.right * speed * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.W))
            {
                ch_move = true;
                if (ch_move_ani == false)
                {
                    StartCoroutine(C_MoveAni());
                }

                transform.Translate(Vector2.up * speed * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.S))
            {
                ch_move = true;
                if (ch_move_ani == false)
                {
                    StartCoroutine(C_MoveAni());
                }

                transform.Translate(Vector2.down * speed * Time.deltaTime);

            }
            else
            {
                ch_move = false;

            }
        }
        else if (ch_movePick == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.W))
            {

                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
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
    void C_rotation()
    {
        Vector3 mPosition = Input.mousePosition; //마우스 좌표 저장
        Vector3 oPosition = transform.position; //게임 오브젝트 좌표 저장

       
        mPosition.z = oPosition.z - Camera.main.transform.position.z;

        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

        
        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;

        
        rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree-90.0f);
    }


void Ch_KeyInput()
    {
        if (Input.GetMouseButton(0)&& ch_movePick==false)
        {
            
            StartCoroutine(Pickax());
            StartCoroutine(Pickax_Hit());
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
        Instantiate(Pick,this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(Pick, this.transform.position, Quaternion.identity);
        yield return null;
    }






}

