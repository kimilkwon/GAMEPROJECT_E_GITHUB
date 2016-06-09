using UnityEngine;
using System.Collections;

public class MonsterSpawn : MonoBehaviour {
    public GameObject monster;
    float creatTime = 3.0f;
    float spawnTime = 3.0f;

    // Use this for initialization
    void Start () {
        StartCoroutine("Monster_");
       
	}
	
	// Update is called once per frame
	void Update () {
      
       
    }
    IEnumerator Monster_()
    {
        yield return new WaitForSeconds(spawnTime);
        yield return null;
        StartCoroutine("Monster_Spawn_Create");
    }
    IEnumerator Monster_Spawn_Create()
    {

            Instantiate(monster, this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(creatTime);
            StartCoroutine("Monster_Spawn_Create");
            yield return null;
        

    }
}
