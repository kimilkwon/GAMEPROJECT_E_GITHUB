using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

    GameObject player;
    float speed= 0.25f;
    bool start = false;
    Vector3 PlayerMovementTarget;
    Monster_Animation monAnimation =null;
    int movement = 0;
    int movementMax = 0;
    float hp = 5;
    NavMeshAgent nav;
    void Start()
    {
        
    }
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER");
        nav = GetComponent<NavMeshAgent>();
        monAnimation = GetComponentInChildren<Monster_Animation>();
    }
    void OnTriggerEnter(Collider coll)//충돌 체크 함수
    {
     
        if (coll.gameObject.tag == "BULLET")
        {

            hp -= 1;
            if(monAnimation.beShotBool==false&& monAnimation.dieBool == false)
            StartCoroutine(monAnimation.beShot());
            if (hp <= 0)
            {
                if (monAnimation.dieBool == false)
                    StartCoroutine(monAnimation.Die());

            }
        }
    }
    public void TakeDamage(float damage)
    {
        if (monAnimation.dieBool == false)
        {
            hp -= damage;
            StartCoroutine(monAnimation.beShot());
            if (hp <= 0)
            {
                StartCoroutine(monAnimation.Die());

            }
        }
    }
    public void Die()
    {
       if(monAnimation.die==true)
            Destroy(this.gameObject);
        
        
    }
    void Update()
    {
       
        if (monAnimation.dieBool == false)
        {
            nav.SetDestination(player.transform.position);
        }
        else  {
            nav.SetDestination(this.transform.position);
        }
        Die();
    }
    

}


