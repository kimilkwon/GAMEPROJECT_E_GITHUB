using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	Transform turretTransform;

	public float range = 10f;
	public GameObject bulletPrefab;

	public int cost = 5;

	float fireCooldown = 0.5f;
	float fireCooldownLeft = 0;

	public float damage = 1;
	public float radius = 0;

	// Use this for initialization
	void Start () {
		turretTransform = transform.Find("Turret");
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: Optimize this!
		Monster[] monsters = GameObject.FindObjectsOfType<Monster>();

        Monster nearestEnemy = null;
		float dist = Mathf.Infinity;

		foreach(Monster m in monsters) {
			float d = Vector3.Distance(this.transform.position, m.transform.position);
			if(nearestEnemy == null || d < dist) {
				nearestEnemy = m;
				dist = d;
			}
		}

		if(nearestEnemy == null) {
			Debug.Log("No enemies?");
			return;
		}

		Vector3 dir = nearestEnemy.transform.position - this.transform.position;

		Quaternion lookRot = Quaternion.LookRotation( dir );

		//Debug.Log(lookRot.eulerAngles.y);
		turretTransform.rotation = Quaternion.Euler( 0, lookRot.eulerAngles.y, 0 );

		fireCooldownLeft -= Time.deltaTime;
		if(fireCooldownLeft <= 0 && dir.magnitude <= range) {
			fireCooldownLeft = fireCooldown;
			ShootAt(nearestEnemy);
		}

	}

	void ShootAt(Monster e) {
		// TODO: Fire out the tip!
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);

		Bullet b = bulletGO.GetComponent<Bullet>();
		b.target = e.transform;
		b.damage = damage;
		b.radius = radius;
	}
}
