using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Attack Collision Detected");
    }
}
