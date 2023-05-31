using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    private GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        enemyPrefab = enemy;
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnEnemy() {
        string newID = $"Enemy";
        Vector3 pos = this.transform.position;
        GameObject newEnemy = Instantiate(enemyPrefab, pos, Quaternion.Euler(Vector3.zero));
    }
}
