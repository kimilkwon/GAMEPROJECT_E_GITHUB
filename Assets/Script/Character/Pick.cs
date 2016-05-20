using UnityEngine;
using System.Collections;

public class Pick : MonoBehaviour
{
    float speed = 1.5f;
    Vector3 mPosition;
    Vector2 Direction;
    Vector3 target;
    // Use this for initialization
    void Start()
    {
         
        mPosition = Input.mousePosition; //마우스 좌표 저장


        Destroy(this.gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 oPosition = transform.position; //게임 오브젝트 좌표 저장


        mPosition.z = this.transform.position.z - Camera.main.transform.position.z;

        target = Camera.main.ScreenToWorldPoint(mPosition);
        target.y -= 10;
        //Direction = (target - this.transform.position);
        target.Normalize();
        this.transform.Translate(target * speed * Time.deltaTime);
    }
}
