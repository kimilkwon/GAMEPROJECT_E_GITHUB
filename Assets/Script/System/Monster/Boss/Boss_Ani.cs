using UnityEngine;
using System.Collections;

public class Boss_Ani : MonoBehaviour
{

    Animator animator;
    public GameObject bullet;
    float oneShoting = 10;
    float bulletSpeed = 100.0f;
    bool attack_bool;
    bool stop_bool;
    public bool die_bool;
    bool die_startbool;
    public AudioSource Audio = null;
    public AudioClip boss_sound = null;


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
        if (attack_bool == false && die_startbool == false)
        {
            animator.Play("boss");
        }
    }
    public IEnumerator Attack()
    {
        attack_bool = true;
        animator.Play("boss_attack");
        Boss_attack();
        yield return new WaitForSeconds(0.15f);
        yield return null;
        attack_bool = false;
    }
 
    public IEnumerator boss_boom()
    {
        die_startbool = true;
        animator.Play("boss_boom");
        yield return new WaitForSeconds(1.0f);
        yield return null;
        die_bool = true;
    }
    public void Boss_attack()
    {
        rand_sound();
        for (int i = 0; i < oneShoting; i++)
        {

            GameObject obj;
           
            obj = (GameObject)Instantiate(bullet, this.transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().AddForce(new Vector3(bulletSpeed * Mathf.Cos(Mathf.PI * 2 * i / oneShoting),0f, bulletSpeed * Mathf.Sin(Mathf.PI * i * 2 / oneShoting)));
            obj.transform.Rotate(new Vector3(0f, 360 * i / oneShoting - 90,0f));
        }
    }
    public IEnumerator Boss_Change()
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();

        sprite.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        sprite.color = Color.white;
      
        yield return null;

    }
    void rand_sound()
    {
        int rnd;
        rnd = Random.Range(0, 3);
        if(rnd==2)
        {
            Audio.clip = boss_sound;
            Audio.volume = 0.5f;
            Audio.Play();
            
        }
    }
}
