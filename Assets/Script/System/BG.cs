using UnityEngine;
using System.Collections;

public class BG : MonoBehaviour {

    // Use this for initialization
    void OnTriggerEnter(Collider coll)//충돌 체크 함수
    {

        if (coll.gameObject.tag == "BULLET")
        {

           
            Destroy(coll.gameObject);
        }
    }
}
