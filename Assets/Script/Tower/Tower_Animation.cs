using UnityEngine;
using System.Collections;

public class Tower_Animation : MonoBehaviour {
    Animator animator;
    bool shot = false;
    public bool boom = false;
    public bool boom_check = false;
    public bool construct = false;
    bool complete = false;

    public AudioSource Audio = null;

    public AudioClip shot_sound = null;

    // Use this for initialization
    void Start () {
       

    }
    void Awake()
    {
        animator = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
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
        if (boom_check == false && boom == false)
        {
            animator.Play("TOWER_Shot");
            Audio.clip = shot_sound;
            Audio.volume = 0.5f;
            Audio.Play();
        }
        yield return new WaitForSeconds(0.5f);
        yield return null;
        if (boom_check == false && boom == false)
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
        boom_check = true;
        animator.Play("TOWER_boom");
        yield return new WaitForSeconds(0.3f);
        
        boom = true;
       
        yield return null;

    }

    public void AnimationCtrl()
    {
       
        if (construct!= true&& boom_check==false)
        {
            StartCoroutine(Tconstruct());
        }
        if(shot!=true&&boom!=true&& boom_check==false)
        {
            StartCoroutine(Tcomplete());
        }
       
    }
}
