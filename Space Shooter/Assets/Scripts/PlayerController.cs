using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] private float defaultTimer = 0.3f;
    [SerializeField] private float timer = 1f;

    [SerializeField] GameObject shotPrefab;

    private Rigidbody2D myRB;


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

    }
    void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(shotPrefab, transform.position, transform.rotation);
        }
        //else
        //{
        //    timer -= Time.deltaTime;
        //    if (timer <= 0f)
        //    {
        //        timer = defaultTimer;
        //        Instantiate(shotPrefab, transform.position, Quaternion.identity);

        //    }

        //}
    }
}
