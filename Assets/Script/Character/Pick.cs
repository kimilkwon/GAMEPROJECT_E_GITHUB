using UnityEngine;
using System.Collections;

public class Pick : MonoBehaviour
{
    float speed = 1.5f;

    Vector3 dir;
    Vector3 mPosition;
    // Use this for initialization
    void Start()
    {
         
        mPosition = Input.mousePosition; //마우스 좌표 저장
        set();

        Destroy(this.gameObject, 1.0f);
    }
    void set()
    {

        Vector3 oPosition = transform.position; //게임 오브젝트 좌표 저장


        mPosition.z = oPosition.z - Camera.main.transform.position.z;

        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

        dir = target - this.transform.position;
        dir.y -= 10;
        dir.Normalize();
    }
    // Update is called once per frame
    void Update()
    {
      
        this.transform.Translate(dir * speed * Time.deltaTime);
    }
}
