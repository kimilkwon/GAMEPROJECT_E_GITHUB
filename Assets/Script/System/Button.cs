using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{

    public GameObject drag;
    bool b_check;

    void Awake()
    {
       
    }


    public void StartGUI()
    {
        AutoFade.LoadLevel("test_3D", 2, 3, Color.black);


    }
    public void ManualGUI()
    {
       

        AutoFade.LoadLevel("MANUAL", 1, 1, Color.black);
    }
    public void ExitGUI()
    {
        //  animator.Play("ExitAnimaiton");
        Application.Quit();
    }
    public void BackGUI()
    {
        //  animator.Play("ExitAnimaiton");
        AutoFade.LoadLevel("start", 1, 1, Color.black);
    }


    // Use this for initialization


    void Update()
    {
       
    }
    void OnMouseEnter()
    {
       
            Instantiate(drag, new Vector3(transform.position.x, transform.position.y , transform.position.z+1.0f), transform.rotation);

    }
    void OnMouseExit()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("게임스타트2");
        foreach (GameObject ob in obj)
        {

            Destroy(ob);

        }
    }
}


