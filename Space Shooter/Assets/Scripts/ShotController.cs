using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] private GameObject impactPrefab;
    private Rigidbody2D shotRB;

    // Start is called before the first frame update
    void Start()
    {
        shotRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemie")) {
            collision.GetComponent<Enemie>().loseLifeEnemie(1);
        } 

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().loseLife(1);
        }

        Destroy(gameObject);
        Instantiate(impactPrefab, transform.position, transform.rotation);
    }
}
