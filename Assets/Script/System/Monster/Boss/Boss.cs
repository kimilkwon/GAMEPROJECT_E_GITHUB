using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
    GameObject player;
    Boss_Ani bossani;

    float hp = 5;
    float fireCooldown = 1.0f;
    float fireCooldownLeft = 0;
    float range = 3.0f;
   
    // Use this for initialization
    void Start () {
	
	}
	void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER");
        bossani = GetComponentInChildren<Boss_Ani>();
    }

    void OnTriggerEnter(Collider coll)//충돌 체크 함수
    {

        if (coll.gameObject.tag == "BULLET")
        {

            hp -= 1;
            StartCoroutine(bossani.Boss_Change());
            if (hp <= 0)
            {
                if (bossani.die_bool == false)
                    StopCoroutine(bossani.Attack());
                    StartCoroutine(bossani.boss_boom());

            }
            Destroy(coll.gameObject);
        }
    }
    public void Die()
    {
        if (bossani.die_bool == true)
            Destroy(this.gameObject);


    }
    // Update is called once per frame
    void Update () {
        Vector3 dir = player.transform.position - this.transform.position;

        Quaternion lookRot = Quaternion.LookRotation(dir);

        this.transform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

        fireCooldownLeft -= Time.deltaTime;
        if (fireCooldownLeft <= 0 && dir.magnitude <= range && hp >0)
        {
            fireCooldownLeft = fireCooldown;
            StartCoroutine(bossani.Attack());
        }
        Die();
    }
}
