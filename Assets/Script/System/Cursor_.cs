using UnityEngine;
using System.Collections;

public class Cursor_ : MonoBehaviour {


    
    public Texture2D cursorTexture; //
    public Texture2D cursorTexture2;
    public Texture2D cursorTexture3;
    
    public bool hotSpotIsCenter = false;
   
    public Vector2 adjustHotSpot = Vector2.zero;
    
    private Vector2 hotSpot;

    int mode = 0;
    public void Start()
    {


        StartCoroutine(MyCursor());
    }

    void Update()
    {
        Mode();

    }
   void Mode()
    {
        if(Input.GetMouseButton(0))
        {
            StartCoroutine(MyCursor());
        }
        if (Input.GetMouseButton(1))
        {
            StartCoroutine(MyCursor2());
        }
        if (Input.GetMouseButtonUp(1))
        {
            StartCoroutine(MyCursor());
        }
        if (Input.GetKey(KeyCode.E))
        {
            StartCoroutine(MyCursor3());
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            StartCoroutine(MyCursor());
        }
    }
    IEnumerator MyCursor()
    {

        
        yield return new WaitForEndOfFrame();

       
        if (hotSpotIsCenter)
        {
            hotSpot.x = cursorTexture.width / 2;
            hotSpot.y = cursorTexture.height / 2;
        }
        else {
            //중심을 사용하지 않을 경우 Adjust Hot Spot으로 입력 받은 
            //것을 사용합니다.
            hotSpot = adjustHotSpot;
        }
        //이제 새로운 마우스 커서를 화면에 표시합니다.
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
    IEnumerator MyCursor2()
    {


        yield return new WaitForEndOfFrame();


        if (hotSpotIsCenter)
        {
            hotSpot.x = cursorTexture2.width / 2;
            hotSpot.y = cursorTexture2.height / 2;
        }
        else {
            //중심을 사용하지 않을 경우 Adjust Hot Spot으로 입력 받은 
            //것을 사용합니다.
            hotSpot = adjustHotSpot;
        }
        //이제 새로운 마우스 커서를 화면에 표시합니다.
        Cursor.SetCursor(cursorTexture2, hotSpot, CursorMode.Auto);
    }
    IEnumerator MyCursor3()
    {


        yield return new WaitForEndOfFrame();


        if (hotSpotIsCenter)
        {
            hotSpot.x = cursorTexture3.width / 2;
            hotSpot.y = cursorTexture3.height / 2;
        }
        else {
            //중심을 사용하지 않을 경우 Adjust Hot Spot으로 입력 받은 
            //것을 사용합니다.
            hotSpot = adjustHotSpot;
        }
        //이제 새로운 마우스 커서를 화면에 표시합니다.
        Cursor.SetCursor(cursorTexture3, hotSpot, CursorMode.Auto);
    }
}


