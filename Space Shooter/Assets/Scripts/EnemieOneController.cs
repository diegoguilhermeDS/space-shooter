using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieOneController : MonoBehaviour
{

    private Rigidbody2D enemieRB;
    [SerializeField] private float speedEnemie = -3f;

    [SerializeField] private GameObject myShot;
    [SerializeField] private Transform positionShot;

    private float timer = 1f;
    [SerializeField] private float awaitShot = 1f;

    [SerializeField] private int lifeEnemie = 10;

    // Start is called before the first frame update
    void Start()
    {
        enemieRB = GetComponent<Rigidbody2D>();

        float posX = Random.Range(-5f, 5f);

        enemieRB.velocity = new Vector2(0, speedEnemie);

        awaitShot = Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        bool isVisible = GetComponentInChildren<SpriteRenderer>().isVisible;
        if (isVisible)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                awaitShot = Random.Range(0.5f, 1f);
                timer = awaitShot;
                Instantiate(myShot, positionShot.position, transform.rotation);
            }

        }

        if (lifeEnemie <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void loseLifeEnemie(int damage)
    {
        lifeEnemie = lifeEnemie - damage;
    }
}
