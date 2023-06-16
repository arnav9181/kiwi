using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool randomizePatrolDistance = false;
    public bool randomizeSpeed = false;
    public bool chasePlayer = false;
    public float minSpeed = 1f;
    public float maxSpeed = 4f;
    public float speed = 2f;
    public float patrolDistance = 10f;
    public float minPatrolDistance = 5f;
    public float maxPatrolDistance = 15f;
    public float chaseDistance = 5f;
    public float verticalTolerance = 1f;  
    private float leftLimit;
    private float rightLimit;
    private int direction = -1; 
    private GameObject player;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        speed = randomizeSpeed ? Random.Range(minSpeed, maxSpeed) : speed;
        patrolDistance = randomizePatrolDistance ? Random.Range(minPatrolDistance, maxPatrolDistance) : patrolDistance;
        float startingPosition = transform.position.x;
        animator.SetBool("IsWalking", true);
        leftLimit = startingPosition - patrolDistance;
        rightLimit = startingPosition + patrolDistance;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (chasePlayer && Vector2.Distance(transform.position, player.transform.position) <= chaseDistance &&
            Mathf.Abs(transform.position.y - player.transform.position.y) <= verticalTolerance)  
        {
            direction = (transform.position.x < player.transform.position.x) ? 1 : -1;
        }
        else
        {
            if (transform.position.x >= rightLimit)
            {
                direction = -1; // move left
            }
            else if (transform.position.x <= leftLimit)
            {
                direction = 1; // move right
            }
        }

        Flip(direction);
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
    }

    private void Flip(int direction)
    {
        if ((direction == 1 && transform.localScale.x > 0) || (direction == -1 && transform.localScale.x < 0))
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
