using UnityEngine;
using System.Collections;

public class Monster_Animation : MonoBehaviour {

    Animator animator;
    public bool beShotBool =false;
    public bool dieBool = false;
    public bool die = false;
    // Use this for initialization
    void Start () {
	
	}
    void Awake()
    {
        animator = GetComponent<Animator>();
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
        yield return new WaitForSeconds(0.15f);
        yield return null;
        
        beShotBool = false;
    }
    public IEnumerator Die()
    {
        dieBool = true;
        animator.Play("Zombi_Die");
        yield return new WaitForSeconds(0.5f);
        yield return null;
        die= true;
    }
}
