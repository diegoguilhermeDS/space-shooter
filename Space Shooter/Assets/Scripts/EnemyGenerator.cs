using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    [SerializeField] private GameObject[] enemies;

    [SerializeField] private int points = 0;
    [SerializeField] private int nextLevel = 100;
    [SerializeField] private int level = 1;

    private float timeToCreateEnemie = 0f;
    [SerializeField] private float awaitTime = 5f;
    [SerializeField] private int enemieQuantityCreated = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GenerateEnemie();
    }

    private void GenerateEnemie()
    {
        if (timeToCreateEnemie > 0 && enemieQuantityCreated <= 0)
        {
            timeToCreateEnemie -= Time.deltaTime;
        }

        if (timeToCreateEnemie <= 0f && enemieQuantityCreated <= 0)
        {
            int quantity = level * 4;

            while (enemieQuantityCreated < quantity)
            {
                GameObject enemieToCreate;

                float chance = Random.Range(0, level);
                if (chance >= 2f)
                {
                    enemieToCreate = enemies[1];
                }
                else
                {
                    enemieToCreate = enemies[0];
                }

                float posY = Random.Range(6, 12);
                float posX = Random.Range(-8.4f, 8.4f);
                Vector3 position = new Vector3(posX, posY, 0);
                Instantiate(enemieToCreate, position, transform.rotation);
                enemieQuantityCreated++;
                timeToCreateEnemie = awaitTime;
            }
        }
    }

    public void Earnpoints(int points)
    {
        this.points += points;

        if (this.points > nextLevel * level)
        {
            level++;
        }
    } 

    public void DecreeaseAmountOfEnemies()
    {
        enemieQuantityCreated--;
    }
}
