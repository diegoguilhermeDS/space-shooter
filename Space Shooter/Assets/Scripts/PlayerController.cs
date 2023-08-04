using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private float defaultTimer = 0.3f;
    //[SerializeField] private float timer = 1f;

    [SerializeField] private GameObject shotPrefab;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Transform positionShotPlayer;

    private Rigidbody2D myRB;
    [SerializeField] private int life = 10;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedShot = 10f;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        fire();


    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 mySpeed = new Vector2(horizontal, vertical);
        mySpeed.Normalize();

        myRB.velocity = mySpeed * speed;
    }

    void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject shot = Instantiate(shotPrefab, positionShotPlayer.position, transform.rotation);
            shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speedShot);
        }
        //else
        //{
        //    timer -= Time.deltaTime;
        //    if (timer <= 0f)
        //    {
        //        timer = defaultTimer;
        //        Instantiate(shotPrefab, transform.position, transform.rotation);

        //    }

        //}
    }

    public void loseLife(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }

    }
}
