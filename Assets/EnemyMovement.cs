using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float patrolDistance = 10f;
    private float leftLimit;
    private float rightLimit;
    private int direction = 1; // 1 for moving right, -1 for moving left
    private SpriteRenderer spriteRenderer; // To flip the sprite depending on the direction

    // Start is called before the first frame update
    void Start()
    {
        float startingPosition = transform.position.x;
        leftLimit = startingPosition - patrolDistance;
        rightLimit = startingPosition + patrolDistance;
        spriteRenderer = GetComponent<SpriteRenderer>(); // get the SpriteRenderer component
          if (direction == 1)
        {
            spriteRenderer.flipX = true; // sprite faces right
        }
        else
        {
            spriteRenderer.flipX = false; // sprite faces left
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rightLimit)
        {
            direction = -1; // move left
            spriteRenderer.flipX = false; // sprite faces left
        }
        else if (transform.position.x < leftLimit)
        {
            direction = 1; // move right
            spriteRenderer.flipX = true; // sprite faces right
        }

        transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
    }
}

