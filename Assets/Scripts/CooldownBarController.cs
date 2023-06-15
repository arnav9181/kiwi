using UnityEngine;
using UnityEngine.UI;

public class CooldownBarController : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown = 5f;
    private bool isCooldown;
        private void Start()
    {
        imageCooldown.fillAmount = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isCooldown)
        {
            StartCoroutine(StartCooldown());
        }

        if (isCooldown)
        {
            imageCooldown.fillAmount += Time.deltaTime / cooldown;

            if (imageCooldown.fillAmount >= 1f)
            {
                imageCooldown.fillAmount = 0f;
                isCooldown = false;
            }
        }
    }

    private System.Collections.IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isCooldown = false;
    }
}
