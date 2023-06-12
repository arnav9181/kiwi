using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    private static List<string> fruitList = new List<string> { "Apple", "Banana", "Melon", "Cantalopue", "Grape", "Kale" };
    private static Dictionary<string, TextMeshProUGUI> groceryList;

    public static List<string> getFruits() {
        return fruitList;
    }

    public static void setGroceryList(List<string> fruits, List<TextMeshProUGUI> listText) {
        groceryList = new Dictionary<string, TextMeshProUGUI>();
        for (int i=0; i<fruits.Count; i++) {
            groceryList.Add(fruits[i], listText[i]);
        }

    }

    public static void crossOut(string fruit) {
        if (groceryList.ContainsKey(fruit)) {
            groceryList[fruit].text = "<s>" + groceryList[fruit].text + "</s>";
            groceryList.Remove(fruit);
        }
        
        if (groceryList.Count == 0) {
            //Win condition
            Debug.Log("You win!");
        }
        Debug.Log(groceryList.Count);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
