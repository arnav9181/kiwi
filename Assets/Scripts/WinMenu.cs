using UnityEngine;

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
            canvas.enabled = true;
        }
    }
}