using UnityEngine;
using System.Collections;

public class Tower_Animation : MonoBehaviour {
    Animator animator;
    bool shot = false;
    bool boom = false;
    public bool construct = false;
    bool complete = false;
    // Use this for initialization
    void Start () {
	
	}
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update () {
	

	}
    public IEnumerator Tcomplete()
    {
        complete = true;
        animator.Play("TOWER_complete");
        
        yield return null;

       
    }
    public IEnumerator Tshot()
    {
        shot = true;
        animator.Play("TOWER_Shot");
        yield return new WaitForSeconds(0.5f);
        yield return null;
        animator.Play("TOWER_complete");
        shot = false;
    }
    public IEnumerator Tconstruct()
    {
        
        animator.Play("TOWER_construct");
        yield return new WaitForSeconds(0.8f);
        yield return null;
        construct = true;
        animator.Play("TOWER_complete");

    }
    public IEnumerator Tboom()
    {
        
        animator.Play("TOWER_boom");
        yield return new WaitForSeconds(0.15f);
        yield return null;
        boom = true;


    }

    public void AnimationCtrl()
    {
       
        if (construct!= true)
        {
            StartCoroutine(Tconstruct());
        }
        if(shot!=true&&boom!=true)
        {
            StartCoroutine(Tcomplete());
        }
       
    }
}
