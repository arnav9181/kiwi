using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public static AudioSource AlarmAudio;
    private static GameObject[] backgrounds;
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
            Caught();
        }
    }

    public static void Caught(){
        Debug.Log("YOU'VE BEEN CAUGHT");
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        foreach(GameObject b in backgrounds){
            Animator bg = b.GetComponent<Animator>();
            bg.SetBool("IsCaught", true);
        }
        AudioSource mainMusic = GameObject.FindWithTag("MainMusic").GetComponent<AudioSource>();
        mainMusic.Stop();
        AlarmAudio = GameObject.FindWithTag("AlarmAudio").GetComponent<AudioSource>();
        if(!AlarmAudio.isPlaying){
            AlarmAudio.Play();
        }
        GameData.Caught += 1;
    }

    public static void Hidden(){
        // Animator bg = GameObject.FindWithTag("Background").GetComponent<Animator>();
        // bg.SetBool("IsCaught", false);
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        foreach(GameObject b in backgrounds){
            Animator bg = b.GetComponent<Animator>();
            bg.SetBool("IsCaught", false);
        }
        AlarmAudio = GameObject.FindWithTag("AlarmAudio").GetComponent<AudioSource>();
        if(AlarmAudio.isPlaying){
            AlarmAudio.Stop();
        }
        AudioSource mainMusic = GameObject.FindWithTag("MainMusic").GetComponent<AudioSource>();
        if(!mainMusic.isPlaying){
            mainMusic.Play();
        }
    }
}
