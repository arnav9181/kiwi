using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WinMenu : MonoBehaviour
{

    public Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    void Update()
    {
        if (GameData.finished) {
            StartCoroutine(ShowScreen());
        }
    }

    public IEnumerator ShowScreen(){
        yield return new WaitForSeconds(2);
        canvas.enabled = true;
        GameData.finished = false;
        GameData.Caught = 0;
    }
}