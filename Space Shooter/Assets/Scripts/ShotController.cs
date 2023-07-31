using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject impactPrefab;
    private Rigidbody2D shotRB;


    // Start is called before the first frame update
    void Start()
    {
        shotRB = GetComponent<Rigidbody2D>();
        shotRB.velocity = new Vector2(0f, speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemieOne")) {
            collision.GetComponent<EnemieOneController>().loseLifeEnemie(2);
        } 

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().loseLife(5);
        }

        Destroy(gameObject);
        Instantiate(impactPrefab, transform.position, transform.rotation);
    }
}
