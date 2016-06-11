using UnityEngine;
using System.Collections;

public class PickAni : MonoBehaviour {
    public AudioSource Audio = null;
    public AudioClip pick_sound_one = null;
    public AudioClip pick_sound_two = null;
    // Use this for initialization
    void Start () {
        sound_play();
        Destroy(this.gameObject, 0.2f);
    }
	void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }
	// Update is called once per frame
	void Update () {
       
    }
    void sound_play()
    {
        int rnd;
        rnd = Random.Range(0, 1);
        if (rnd == 1)
        {
         
            Audio.clip = pick_sound_one;
            Audio.volume = 30.0f;
            Audio.Play();
        }
        else if(rnd ==0)
        {
            Audio.clip = pick_sound_two;
            Audio.volume = 30.0f;
            Audio.Play();
        }
    }
}
