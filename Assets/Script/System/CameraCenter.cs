using UnityEngine;
using System.Collections;

public class CameraCenter : MonoBehaviour {

    public GameObject Ch;  
    Transform AT;
    void Start()
    {
        AT = Ch.transform;
    }
    void LateUpdate()
    {
        transform.position = new Vector3(AT.position.x, AT.position.y, transform.position.z);
    }


  

 

}
