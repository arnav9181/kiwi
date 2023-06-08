using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float leftLimit;
    private float rightLimit;

    public float distance = .3f;
    public int direction = 1;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        float startingPosition = transform.GetChild(0).transform.rotation.z;
        leftLimit = startingPosition - distance;
        rightLimit = startingPosition + distance;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(transform.GetChild(0).rotation.z);
        if(transform.GetChild(0).rotation.z < leftLimit){
            direction = 1; //go right
        }
        
        if(transform.GetChild(0).rotation.z > rightLimit){
            direction = -1; //go left
        }

        transform.GetChild(0).Rotate(0, 0, speed*direction*Time.deltaTime);
    }
}
