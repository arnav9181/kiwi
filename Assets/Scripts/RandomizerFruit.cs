using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro; 
using UnityEngine.UI;


public class RandomizerFruit : MonoBehaviour
{
    private List<string> fruits;
    public TextMeshProUGUI  text1;
    public TextMeshProUGUI  text2;
    public TextMeshProUGUI  text3;

    public GameObject spriteObject1;
    public GameObject spriteObject2;
    public GameObject spriteObject3;


    // Start is called before the first frame update
    void Start()
    {
        fruits = new List<string> { "Apple", "Banana", "Melon", "Cantalopue", "Grape", "Kale" };
        PickAndAssignRandomFruits();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void PickAndAssignRandomFruits()
    {
        List<string> tempFruits = new List<string>(fruits);
        AssignFruit(text1, spriteObject1, tempFruits);
        AssignFruit(text2, spriteObject2, tempFruits);
        AssignFruit(text3, spriteObject3, tempFruits);
    }

    private void AssignFruit(TextMeshProUGUI textObject, GameObject spriteObject, List<string> fruitList)
    {
        string fruit = PickRandomFruit(fruitList);
        textObject.text = fruit;
        string path = "Assets/Sprites/" + fruit + ".png";

        Sprite fruitSprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);
        if (fruitSprite != null)
        {
            Image sr = spriteObject.GetComponent<Image>();
            if (sr != null)
            {
                sr.sprite = fruitSprite;
                Debug.Log("Assigned " + fruit + " to " + sr.name);

            }
            else
            {
                Debug.LogError("No SpriteRenderer found on " + spriteObject.name);
            }
        }
        else
        {
            Debug.LogError("Sprite not found for " + fruit);
        }
    }

    private string PickRandomFruit(List<string> fruitList)
    {
        if (fruitList.Count == 0) return "";
        int index = Random.Range(0, fruitList.Count);
        string fruit = fruitList[index];
        fruitList.RemoveAt(index);
        return fruit;
    }
}
