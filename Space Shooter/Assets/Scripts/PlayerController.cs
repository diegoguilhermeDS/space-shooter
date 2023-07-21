using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
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

        //    Instantiate(shotPrefab, new Vector3(myRB.position.x, myRB.position.y + .75f, 0), Quaternion.identity);

        //}
    }
}
