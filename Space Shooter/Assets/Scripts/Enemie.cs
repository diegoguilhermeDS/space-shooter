using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    [SerializeField] protected float speedEnemie;
    [SerializeField] protected int lifeEnemie;
    [SerializeField] protected GameObject explosionPrefab;
    [SerializeField] protected GameObject myShot;
    [SerializeField] protected float speedShot = 5f;
    [SerializeField] protected float awaitShot = 1f;
    [SerializeField] protected int points = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loseLifeEnemie(int damage)
    {
        if (transform.position.y <= 5)
        {
            lifeEnemie -= damage;

            if (lifeEnemie <= 0)
            {
                Destroy(gameObject);
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                var generator = FindObjectOfType<EnemyGenerator>();
                generator.DecreeaseAmountOfEnemies();
                generator.Earnpoints(points);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DestroyShot"))
        {
            Destroy(gameObject);
            var generator = FindObjectOfType<EnemyGenerator>();
            generator.DecreeaseAmountOfEnemies();
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            var generator = FindObjectOfType<EnemyGenerator>();
            generator.DecreeaseAmountOfEnemies();
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            other.gameObject.GetComponent<PlayerController>().loseLife(2);
        }
    }
}
