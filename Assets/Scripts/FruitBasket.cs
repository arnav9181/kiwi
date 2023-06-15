using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBasket : MonoBehaviour
{
    public List<Sprite> fruitSprites;
    public enum Fruit:int {Apple = 0, Banana = 1, Cantaloupe = 2, Grape = 3, Kale = 4, Melon = 5}
    private List<string> fruitTags =  new List<string> { "Fruit_Apple", "Fruit_Banana", "Fruit_Cantaloupe", "Fruit_Grape", 
    "Fruit_Kale",  "Fruit_Melon" };
    public Fruit currFruit;

    private SpriteRenderer fruitSR;

    // Start is called before the first frame update
    void Start()
    {
        fruitSR = transform.GetChild(0).GetComponent<SpriteRenderer>();
        fruitSR.sprite = fruitSprites[(int) currFruit];
        fruitSR.tag = fruitTags[(int) currFruit];
        //transform.GetChild(0).transform.localScale = new Vector3(5,,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
