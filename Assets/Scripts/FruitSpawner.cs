using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public float yPos;
    public GameObject fbPrefab;
    public float testPos = 10f;
    private GameObject fruitBasket1;
    private GameObject fruitBasket2;


    private Vector3 fb1pos;
    private Vector3 fb2pos;
    // Start is called before the first frame update
    void Start()
    {
        fb1pos = new Vector3(Random.Range(-53.6f, 53.6f), yPos, 0);
        fb2pos = new Vector3(Random.Range(-53.6f, 53.6f), yPos, 0);
        while(Mathf.Abs(fb1pos.x-fb2pos.x) < testPos){
            fb2pos = new Vector3(Random.Range(-53.6f, 53.6f), yPos, 0);
        }
        fruitBasket1 = Instantiate(fbPrefab, fb1pos, Quaternion.Euler(Vector3.zero));
        fruitBasket2 = Instantiate(fbPrefab, fb2pos, Quaternion.Euler(Vector3.zero));

        fruitBasket1.GetComponent<FruitBasket>().currFruit = (FruitBasket.Fruit)Random.Range(0,6);
        fruitBasket2.GetComponent<FruitBasket>().currFruit = (FruitBasket.Fruit)Random.Range(0,6);
    }

    // Update is called once per frame
    void Update()
    {
    }

}
