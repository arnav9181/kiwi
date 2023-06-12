using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Contains("Fruit")) {
            Debug.Log(collision.tag);
            Destroy(collision.gameObject);
            GameData.crossOut(collision.gameObject.tag.Split("_")[1]);
        }
    }
}
