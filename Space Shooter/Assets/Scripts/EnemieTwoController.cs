using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieTwoController : Enemie
{
    private float timer = 1f;
    private Rigidbody2D enemieRB;
    [SerializeField] private Transform positionShot;
    [SerializeField] private float maxY = 2.5f;
    private bool isNotMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        enemieRB = GetComponent<Rigidbody2D>();

        enemieRB.velocity = Vector2.up * speedEnemie;

        awaitShot = Random.Range(2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shooting();
    }

    private void Move()
    {
        if (transform.position.y <= maxY && isNotMoving)
        {
            if (transform.position.x < 0)
            {
                enemieRB.velocity = new Vector2(speedEnemie * -1, speedEnemie);
                isNotMoving = false;
            }
            else
            {
                enemieRB.velocity = new Vector2(speedEnemie, speedEnemie);
                isNotMoving = false;
            }
        }
    }

    private void Shooting()
    {
        bool isVisible = GetComponentInChildren<SpriteRenderer>().isVisible;
        if (isVisible)
        {
            var player = FindObjectOfType<PlayerController>();
            if (player)
            {
                timer -= Time.deltaTime;
                if (timer <= 0f)
                {
                    GameObject shot = Instantiate(myShot, positionShot.position, transform.rotation);

                    Vector2 directionShot = player.transform.position - shot.transform.position;
                    directionShot.Normalize();

                    float angle = Mathf.Atan2(directionShot.y, directionShot.x) * Mathf.Rad2Deg;
                    shot.transform.rotation = Quaternion.Euler(0, 0, angle + 90);

                    shot.GetComponent<Rigidbody2D>().velocity = directionShot * speedShot;

                    awaitShot = Random.Range(2f, 4f);
                    timer = awaitShot;
                }

            }
        }
    }
}
