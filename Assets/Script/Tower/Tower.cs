using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	Transform turretTransform;
    Tower_Animation tower_animation;
	public float range = 0.5f;
	public GameObject bulletPrefab;

	public int cost = 5;

	float fireCooldown = 1.0f;
	float fireCooldownLeft = 0;

	public float damage = 1;
	public float radius = 0;

	// Use this for initialization
	void Start () {
		turretTransform = transform.Find("Turret");
        turretTransform.rotation = Quaternion.Euler(0,0, 0);

    }
    void Awake()
    {
        tower_animation = GetComponentInChildren<Tower_Animation>();
    }

    void OnTriggerEnter(Collider coll)//충돌 체크 함수
    {

        if (coll.gameObject.tag == "ZOMBI" && tower_animation.boom_check == false&& tower_animation.construct ==true)
        {
            StartCoroutine(tower_animation.Tboom());
           
        }
    }

    void die()
    {
       if(tower_animation.boom == true )
        Destroy(this.gameObject);
    }
	// Update is called once per frame
	void Update () {
       die();
        if (tower_animation.construct == true)
        {
            Monster[] monsters = GameObject.FindObjectsOfType<Monster>();

            Monster nearestEnemy = null;
            float dist = Mathf.Infinity;

            foreach (Monster m in monsters)
            {
                float d = Vector3.Distance(this.transform.position, m.transform.position);
                if (nearestEnemy == null || d < dist)
                {
                    nearestEnemy = m;
                    dist = d;
                }
            }

            if (nearestEnemy == null)
            {
                Debug.Log("No enemies?");
                return;
            }

            Vector3 dir = nearestEnemy.transform.position - this.transform.position;

            Quaternion lookRot = Quaternion.LookRotation(dir);

         
            turretTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

            fireCooldownLeft -= Time.deltaTime;
            if (fireCooldownLeft <= 0 && dir.magnitude <= range)
            {
                fireCooldownLeft = fireCooldown;
                if (tower_animation.boom_check == false && tower_animation.boom == false)
                {
                    StartCoroutine(tower_animation.Tshot());
                    ShootAt(nearestEnemy);
                }
            }
        }
        else
        {
            if (tower_animation.boom_check == false && tower_animation.boom == false)
            {
                StartCoroutine(tower_animation.Tconstruct());
            }
        }

	}

	void ShootAt(Monster e) {
		
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);

		Bullet b = bulletGO.GetComponent<Bullet>();
		b.target = e.transform;
		b.damage = damage;
		b.radius = radius;
	}
}
