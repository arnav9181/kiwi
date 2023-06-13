using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class RandomizerFruit : MonoBehaviour
{
    public Sprite[] allFruitSprites;
    private Dictionary<string, Sprite> fruitSpriteMap;

    private List<string> fruits;
    private List<GameObject> fruitListObjects;
    private List<TextMeshProUGUI> fruitListTexts;

    public TextMeshProUGUI  text1;
    public TextMeshProUGUI  text2;
    public TextMeshProUGUI  text3;

    public GameObject spriteObject1;
    public GameObject spriteObject2;
    public GameObject spriteObject3;

    void Start()
    {
        fruitSpriteMap = new Dictionary<string, Sprite>();
        foreach (Sprite sprite in allFruitSprites)
        {
            fruitSpriteMap[sprite.name] = sprite;
        }

        fruits = ChooseFruits(GameData.getFruits(), 3);
        fruitListTexts = new List<TextMeshProUGUI>(){ text1, text2, text3 };
        fruitListObjects = new List<GameObject>(){ spriteObject1, spriteObject2, spriteObject3 };
        InitializeFruits(fruits);
        GameData.setGroceryList(fruits, fruitListTexts);
    }

    void Update()
    {
        
    }

    private void InitializeFruits(List<string> fruitList) {
        
        string fruit;
        TextMeshProUGUI fruitText;
        GameObject fruitObject;
        Sprite fruitSprite;
        Image spriteImage;
        for (int i=0; i<fruitList.Count; i++) {
            fruit = fruitList[i];
            fruitText = fruitListTexts[i];
            fruitObject = fruitListObjects[i];
            fruitText.text = fruit;
            fruitSprite = fruitSpriteMap.ContainsKey(fruit) ? fruitSpriteMap[fruit] : null;
            if (fruitSprite) {
                spriteImage = fruitObject.GetComponent<Image>();
                if (spriteImage) {
                    spriteImage.sprite = fruitSprite;
                }
            } else {
                Debug.Log("Sprite not found for fruit: " + fruit);
            }
        }
    }

    private List<string> ChooseFruits(List<string> fruitList, int count) {
        List<string> chosenFruits = new List<string>();
        string fruit;
        while (chosenFruits.Count < count) {
            fruit = PickRandomFruit(fruitList);
            if (!chosenFruits.Contains(fruit)) {
                chosenFruits.Add(fruit);   
            }
        }
        return chosenFruits;
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
