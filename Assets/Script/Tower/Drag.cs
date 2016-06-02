using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {
   public GameObject drag;
    bool b_check;
    // Use this for initialization
    void Start () {
	
	}
	void Awake()
    {
         
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.B))
        {
            b_check = true;
        }
        else
        {
            b_check = false;
        }
        
    }
    void OnMouseEnter()
    {
        if(b_check==true)
        Instantiate(drag, new Vector3(transform.position.x, transform.position.y+1.8f, transform.position.z), transform.rotation);

    }
    void OnMouseExit()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("DRAG");
        foreach (GameObject ob in obj)
        {

            Destroy(ob);
           
        }
    }
}
