using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoseMenu : MonoBehaviour
{
    public float timeTowait = 0f;
    public float lives = 3;
    public Canvas canvas2;

    void Start()
    {
        canvas2 = GetComponent<Canvas>();
        canvas2.enabled = false;
    }

    void Update()
    {
    //Change this if condition to when timer runs out
        if (GameData.Caught == lives) {
            StartCoroutine(ShowScreen2());
        }
    }

    public IEnumerator ShowScreen2(){
        yield return new WaitForSeconds(timeTowait);
        canvas2.enabled = true;
        GameData.Caught = 0;
    }
}