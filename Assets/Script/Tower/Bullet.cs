using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 15f;
	public Transform target;
	public float damage = 1f;
	public float radius = 0;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
		if(target == null) {
		
			Destroy(gameObject);
			return;
		}


		Vector3 dir = target.position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distThisFrame) {

			DoBulletHit();
		}
		else {
	
			transform.Translate( dir.normalized * distThisFrame, Space.World );
			Quaternion targetRotation = Quaternion.LookRotation( dir );
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
		}

	}

	void DoBulletHit() {
		

		if(radius == 0) {
			target.GetComponent<Monster>().TakeDamage(damage);
		}
		else {
			Collider[] cols = Physics.OverlapSphere(transform.position, radius);

			foreach(Collider c in cols) {
                Monster m = c.GetComponent<Monster>();
				if(m != null) {
					
					m.GetComponent<Monster>().TakeDamage(damage);
				}
			}
		}

	

		Destroy(gameObject);
	}
}
