using UnityEngine;
using System.Collections;

public class Monster_Animation : MonoBehaviour {

    Animator animator;
    public bool beShotBool =false;
    public bool dieBool = false;
    public bool die = false;


    public AudioSource Audio = null;
    float volume =1.5f;
    public AudioClip dead_sound = null;

    void Start () {
	
	}
    void Awake()
    {
        animator = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update () {
        if (beShotBool == false && dieBool == false)
        {
            animator.Play("Zombi");
        }
    }
    public IEnumerator beShot()
    {
        beShotBool = true;
        animator.Play("Zombi_beShot");
        yield return new WaitForSeconds(0.3f);
        yield return null;
        
        beShotBool = false;
    }
    public IEnumerator Die()
    {
        Audio.clip = dead_sound;
        Audio.volume = volume;
        Audio.Play();
        dieBool = true;
        animator.Play("Zombi_Die");
        yield return new WaitForSeconds(0.5f);
        yield return null;
       
        die = true;
    }
}
