using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

    GameObject player;
    float speed= 0.25f;
    bool start = false;
    Vector3 PlayerMovementTarget;
    Vector3[] MovementTarget = new Vector3[100];
    int movement = 0;
    int movementMax = 0;
    float hp = 500;
    NavMeshAgent nav;
    void Start()
    {
        
    }
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER");
        nav = GetComponent<NavMeshAgent>();
    }
    void OnTriggerEnter2D(Collider2D coll)//충돌 체크 함수
    {
        if (coll.gameObject.tag == "BULLET")
        {
           // hp -= 1;
           
          //  Destroy(coll.gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
       
        Destroy(gameObject);
    }
    void Update()
    {
       
        if (start != false)
        {
            
        }
        nav.SetDestination(player.transform.position);
    }
    

}


