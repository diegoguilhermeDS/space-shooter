using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private GameObject shotObject;

    private Rigidbody2D shotRB;
    // Start is called before the first frame update
    void Start()
    {
        shotRB = GetComponent<Rigidbody2D>();
        shotRB.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
