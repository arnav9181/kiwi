using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    private static List<string> fruitList = new List<string> { "Apple", "Banana", "Melon", "Cantalopue", "Grape", "Kale" };
    private static Dictionary<string, TextMeshProUGUI> groceryList;
    private static float timer = 0f;
    private static float timeToChange = 2f;

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
            //Debug.Log("You win!");
            if(timer >= timeToChange){
                SceneManager.LoadScene(0);
            }
            timer += Time.deltaTime;
            //StartCoroutine(ReturnToMainMenu());
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

    // public IEnumerator ReturnToMainMenu(){
    //     yield return new WaitForSeconds(2);
    //     SceneManager.LoadScene(0);
    // }
}
