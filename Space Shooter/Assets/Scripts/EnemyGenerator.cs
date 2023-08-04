using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    [SerializeField] private GameObject[] enemies;

    private int points = 0;
    [SerializeField] private int level = 1;

    private float timeToCreateEnemie = 0f;
    [SerializeField] private float awaitTime = 5f;

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
        if (timeToCreateEnemie > 0)
        {
            timeToCreateEnemie -= Time.deltaTime;
        }

        if (timeToCreateEnemie <= 0f)
        {
            GameObject enemieToCreate;

            float chance = Random.Range(0, level);
            if (chance > 4f)
            {
                enemieToCreate = enemies[1];
            }
            else
            {
                enemieToCreate = enemies[0];
            }

            float posY = Random.Range(6, 12);
            float posX = Random.Range(-8.4f, 8.4f);
            Vector3 position = new Vector3(posX,posY,0);
            Instantiate(enemieToCreate, position, transform.rotation);
            timeToCreateEnemie = awaitTime;
        }
    }
}
