using UnityEngine;
using System.Collections;

public class Boss_Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 3.0f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
