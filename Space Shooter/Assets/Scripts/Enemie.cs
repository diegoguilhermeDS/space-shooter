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
    protected float awaitShot = 1f;

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
        lifeEnemie -= damage;

        if (lifeEnemie <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DestroyShot"))
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            other.gameObject.GetComponent<PlayerController>().loseLife(2);
        }
    }
}
