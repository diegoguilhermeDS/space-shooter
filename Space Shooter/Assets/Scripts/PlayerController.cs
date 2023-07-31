using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    //[SerializeField] private float defaultTimer = 0.3f;
    //[SerializeField] private float timer = 1f;

    [SerializeField] GameObject shotPrefab;
    [SerializeField] Transform positionShotPlayer;

    private Rigidbody2D myRB;

    [SerializeField] private int life = 50;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 mySpeed = new Vector2(horizontal, vertical);
        mySpeed.Normalize();

        myRB.velocity = mySpeed * speed;
        fire();

        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }
    void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(shotPrefab, positionShotPlayer.position, transform.rotation);
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
        life = life - damage;
    }
}
