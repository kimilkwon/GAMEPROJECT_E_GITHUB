using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    // Use this for initialization

    int speed = 5; //스피드 
    void Update()
    {
        C_Move();

    }

    void C_Move()
    {

        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축으로 이동할 양 
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime; //y축으로 이동할양 
        this.transform.Translate(new Vector3(xMove, yMove, 0));  //이동
    }
  
    
}
