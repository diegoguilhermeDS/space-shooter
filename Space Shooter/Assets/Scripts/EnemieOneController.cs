using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieOneController : Enemie
{

    private float timer = 1f;
    private Rigidbody2D enemieRB;
    [SerializeField] private Transform positionShot;

    // Start is called before the first frame update
    void Start()
    {
        enemieRB = GetComponent<Rigidbody2D>();
        speedShot = 6f;

        // possible implement to enemie to be move in X
        //float posX = Random.Range(-5f, 5f);

        enemieRB.velocity = new Vector2(0, speedEnemie);

        awaitShot = Random.Range(1.5f, 2.5f);
    }
     
    // Update is called once per frame
    void Update()
    {
        Shooting();

    }

    private void Shooting()
    {
        bool isVisible = GetComponentInChildren<SpriteRenderer>().isVisible;
        if (isVisible)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                awaitShot = Random.Range(1.5f, 2.5f);
                timer = awaitShot;
                GameObject shot = Instantiate(myShot, positionShot.position, transform.rotation);
                shot.GetComponent<Rigidbody2D>().velocity = Vector2.down * speedShot;
            }

        }
    }
}
