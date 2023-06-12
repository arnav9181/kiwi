using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBarController : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown = 5;
    bool isCooldown;
    bool isHidden;

    private float hideTime = 1.5f;
    private float hideCooldownTime = 2f;
    private float hideTimer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isHidden)
        {
            isCooldown = true;
            isHidden = true;
            StartCoroutine(StartHideCooldown());
        }

        if (isCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;

            if (imageCooldown.fillAmount >= 1)
            {
                imageCooldown.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    IEnumerator StartHideCooldown()
    {
        yield return new WaitForSeconds(hideTime);

        isHidden = false;
        yield return new WaitForSeconds(hideCooldownTime);

        isCooldown = true;
    }
}
