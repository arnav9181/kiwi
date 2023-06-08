using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    private AudioSource AlarmAudio;
    //public GameObject AlarmAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            Debug.Log("YOU'VE BEEN CAUGHT");
            Animator bg = GameObject.FindWithTag("Background").GetComponent<Animator>();
            bg.SetBool("IsCaught", true);
            AudioSource mainMusic = GameObject.FindWithTag("MainMusic").GetComponent<AudioSource>();
            mainMusic.Stop();
            AlarmAudio = GameObject.FindWithTag("AlarmAudio").GetComponent<AudioSource>();
            if(!AlarmAudio.isPlaying){
                AlarmAudio.Play();
            }
        }
    }
}
