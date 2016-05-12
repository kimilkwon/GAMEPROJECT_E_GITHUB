using UnityEngine;
using System.Collections;

public class Pick : MonoBehaviour
{
    float speed = 1.5f;
    Vector3 mouse;
    Vector2 Direction;
    Vector3 target;
    // Use this for initialization
    void Start()
    {
         mouse = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(mouse);
        Direction = (target - this.transform.position);
         
        Destroy(this.gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        Direction.Normalize();
        this.transform.Translate(Direction * speed * Time.deltaTime);
    }

}
