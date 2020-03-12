using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public int roundNum = 1;
    public int enemiesLeft;
    public int spawnCount;
    public GameObject spawnOne, spawnTwo, spawnThree;
    public GameObject enemyPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyHasDied()
    {
        enemiesLeft--;
        print(enemiesLeft);

        if (enemiesLeft == 0)
        {
            // Enable 'Cleared' UI menu here
            // Destroy this if needs be
            NewRound();
        }
    }
    public void NewRound()
    {
        //increase roundNum
        roundNum++;
        //spawn enemies at each spawnpoint
        spawnCount = roundNum;
        //times round number
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(enemyPrefab, spawnOne.transform);
            enemiesLeft++;
        }
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(enemyPrefab, spawnTwo.transform);
            enemiesLeft++;
        }
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(enemyPrefab, spawnThree.transform);
            enemiesLeft++;
        }
    }
    
}
