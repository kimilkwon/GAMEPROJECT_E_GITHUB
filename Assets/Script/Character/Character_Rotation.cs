using UnityEngine;
using System.Collections;

public class Character_Rotation : MonoBehaviour {
    Transform characterTransform;

    float rotateSpeed = 5.0f;
    // Use this for initialization
    void Start () {
        characterTransform = transform.Find("Character");
    }
	
	// Update is called once per frame
	void Update () {
        Rotation();

    }
    void Awake()
    {
        //rigidbody = GetComponent<Rigidbody>();
    }
    void Rotation()
    {

        Vector3 mPosition = Input.mousePosition; //마우스 좌표 저장
        Vector3 oPosition = transform.position; //게임 오브젝트 좌표 저장


       mPosition.z = oPosition.z - Camera.main.transform.position.z;

        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);
       // target.y -= 10;

        Vector3 dir = target - this.transform.position;
        dir.y -= 10;
        Quaternion lookRot = Quaternion.LookRotation(dir);

        //Debug.Log(lookRot.eulerAngles.y);
       this.transform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);



        




    }

}
