using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
    GameObject player;
    Boss_Ani bossani;
    BossUI bossUI;
    float hp = 5;
    float fireCooldown = 1.0f;
    float fireCooldownLeft = 0;
    float range = 4.5f;

    public AudioSource Audio = null;
    public AudioClip boss_sound = null;
    
    public GameObject bullet;
    float oneShoting = 10;
    float bulletSpeed = 100.0f;
    // Use this for initialization
    void Start () {
	
	}
	void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER");
        bossani = GetComponentInChildren<Boss_Ani>();
        bossUI = GameObject.Find("BossUI").GetComponent<BossUI>();
        Audio = GetComponent<AudioSource>();
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
        {
            bossUI.Change_UI_Boss();
            Destroy(this.gameObject);
        }

    }
    public void Boss_attack()
    {
        oneShoting = Random.Range(10, 20);
        rand_sound();
        for (int i = 0; i < oneShoting; i++)
        {

            GameObject obj;

            obj = (GameObject)Instantiate(bullet, this.transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().AddForce(new Vector3(bulletSpeed * Mathf.Cos(Mathf.PI * 2 * i / oneShoting), 0f, bulletSpeed * Mathf.Sin(Mathf.PI * i * 2 / oneShoting)));
            obj.transform.Rotate(new Vector3(0f, 360 * i / oneShoting - 90, 0f));
        }
    }
    // Update is called once per frame
    void Update () {
        Vector3 dir = player.transform.position - this.transform.position;

        Quaternion lookRot = Quaternion.LookRotation(dir);

        this.transform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

        fireCooldownLeft -= Time.deltaTime;
        if (fireCooldownLeft <= 0 && dir.magnitude <= range && hp >0)
        {
            fireCooldownLeft = Random.Range(0.1f,1.5f);
            StartCoroutine(bossani.Attack());
            Boss_attack();
        }
        Die();
    }
    void rand_sound()
    {
        int rnd;
        rnd = Random.Range(0, 3);
        if (rnd == 2)
        {
            Audio.clip = boss_sound;
            Audio.volume = 0.5f;
            Audio.Play();

        }
    }
}
