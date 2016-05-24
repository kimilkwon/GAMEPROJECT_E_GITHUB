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
    float hp = 500;
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
    
    public void TakeDamage(float damage)
    {
        
        hp -= damage;
       StartCoroutine(monAnimation.beShot());
        if (hp <= 0)
        {
            StartCoroutine(monAnimation.Die());
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


