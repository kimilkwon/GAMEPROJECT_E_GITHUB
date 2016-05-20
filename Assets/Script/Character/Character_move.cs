using UnityEngine;
using System.Collections;

public class Character_move : MonoBehaviour {
    int speed = 5;
    float rotateDegree = 0.0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKey(KeyCode.A))
                {
                    

                    transform.Translate(Vector3.left * speed * Time.deltaTime);

                }
                if (Input.GetKey(KeyCode.D))
                {

                    transform.Translate(Vector3.right * speed * Time.deltaTime);

                }
                if (Input.GetKey(KeyCode.W))
                {
                 transform.Translate(Vector3.forward * speed * Time.deltaTime);

                }
                if (Input.GetKey(KeyCode.S))
                {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
       
        }
       
        }
   
    }


