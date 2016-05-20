using UnityEngine;
using System.Collections;

public class Bullet2 : MonoBehaviour {

    // Use this for initialization
    float speed = 10f;
    Vector3 mouse;
    Vector2 Direction;
    Vector3 target;
    // Use this for initialization
    void Start()
    {
        mouse = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(mouse);
        Direction = (target - this.transform.position);
        Direction.Normalize();
        Destroy(this.gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
     
       
        this.transform.Translate(Direction * speed * Time.deltaTime);
    }
}
