using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoseMenu : MonoBehaviour
{

    public Canvas canvas2;

    void Start()
    {
        canvas2 = GetComponent<Canvas>();
        canvas2.enabled = false;
    }

    void Update()
    {
    //Change this if condition to when timer runs out
        if (GameData.finished) {
            StartCoroutine(ShowScreen2());
        }
    }

    public IEnumerator ShowScreen2(){
        yield return new WaitForSeconds(2);
        canvas2.enabled = true;
        GameData.finished = false;
    }
}