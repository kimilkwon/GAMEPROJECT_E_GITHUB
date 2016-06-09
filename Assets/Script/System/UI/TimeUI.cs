using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{


    float sec = 0;
    float min = 0;
    //private float Time_ = 0;
    public Text secText = null;

    // Use this for initialization
    void Start()
    {

        StartCoroutine(TIMEUPDATE());
        TimeUp();

    }

    public void TimeUp()
    {
       
        secText.text =  min.ToString()+":"+sec.ToString();
      
    }
    void time_set()
    {
        if(sec>=60.0f)
        {
            sec = 0f;
            min += 1.0f;
        }
    }

    public IEnumerator TIMEUPDATE()
    {
        yield return new WaitForSeconds(1f); // 쿨타임
        sec += 1f;
        time_set();
        yield return null;
        StartCoroutine(TIMEUPDATE());
        TimeUp();

    }
    void Update()
    {
       
    }
}
