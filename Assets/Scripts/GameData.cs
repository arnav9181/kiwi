using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    private static List<string> fruitList = new List<string> { "Apple", "Banana", "Melon", "Cantaloupe", "Grape", "Kale" };
    private static Dictionary<string, TextMeshProUGUI> groceryList;
    private static float timer = 0f;
    private static float timeToChange = 2f;
    public static bool finished = false;

    public static int Caught = 0;

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
            finished = true;
            // StartCoroutine(GameObject.FindWithTag("WinMenu").GetComponent<WinMenu>().ShowScreen());
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
        if(timer >= timeToChange){
            SceneManager.LoadScene(0);
        }
        else if(finished){
            Debug.Log("Timer is incrimenting");
            timer += Time.deltaTime;
        }
    }

    // public IEnumerator ShowWinScreen(){
    //     yield return new WaitForSeconds(2);
    //     //SceneManager.LoadScene(0);
    //     GameObject.FindWithTag("WinMenu").GetComponent<WinMenu>().ShowScreen();
    // }
}
