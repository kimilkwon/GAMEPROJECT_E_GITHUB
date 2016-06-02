using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Center : MonoBehaviour
{


    int zircon = 0;
    int  mis = 0;
    int zunke = 0;
    int kang = 0;
    //private float Time_ = 0;
    public Text zirconText = null;
    public Text zunkeText = null;
    public Text misText = null;
    public Text kangText = null;
    // Use this for initialization
    void Start()
    {

      
       

    }

   void misView()
    {

        misText.text = mis.ToString();

    }
    void zirconView()
    {

        zirconText.text = zircon.ToString();

    }
    void zunkeView()
    {

        zunkeText.text = zunke.ToString();

    }
    void kangView()
    {

        kangText.text = kang.ToString();

    }

    public void viewUp(int item)
    {
        switch (item)
        {
            case 1:
                mis += 1;
                break;
            case 2:
                zircon += 1;
                break;
            case 3:
                zunke += 1;
                break;
            case 4:
                kang += 1;
                break;
        }
           
    }



    void Update()
    {
        kangView();
        misView();
        zirconView();
        zunkeView();
    }
}
