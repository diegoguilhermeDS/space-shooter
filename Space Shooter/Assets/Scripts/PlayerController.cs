using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private float defaultTimer = 0.3f;
    //[SerializeField] private float timer = 1f;

    [SerializeField] private Transform positionShotPlayer;
    [SerializeField] private GameObject shotPrefab;
    [SerializeField] private GameObject shotTwoPrefab;
    [SerializeField] private GameObject explosionPrefab;

    private Rigidbody2D myRB;
    [SerializeField] private int life = 10;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedShot = 10f;
    [SerializeField] private float speedShotTwo = 16f;

    [SerializeField] private float limitX;
    [SerializeField] private float limitY;

    [SerializeField] private int levelShot = 1;

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

        float checkingMyX = Mathf.Clamp(transform.position.x, -limitX, limitX);
        float checkingMyY = Mathf.Clamp(transform.position.y, -limitY, limitY);

        transform.position = new Vector3(checkingMyX, checkingMyY, transform.position.z);
    }

    void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (levelShot <= 1)
            {
                CreateShot(shotPrefab, positionShotPlayer.position, speedShot);
            } else
            {
                speedShot = 16f;

                Vector3 positionShotLeft = new Vector3(positionShotPlayer.position.x - 0.45f, positionShotPlayer.position.y - 0.1f, 0f);
                Vector3 positionShotRight = new Vector3(positionShotPlayer.position.x + 0.45f, positionShotPlayer.position.y - 0.1f, 0f);

                CreateShot(shotTwoPrefab, positionShotLeft, speedShotTwo);
                CreateShot(shotTwoPrefab, positionShotRight, speedShotTwo);
            }
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

    private void CreateShot(GameObject shotPrefab, Vector3 position, float speedShot)
    {
        GameObject shot = Instantiate(shotPrefab, position, transform.rotation);
        shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speedShot);
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
