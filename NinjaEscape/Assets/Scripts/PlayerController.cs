using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5;
    float jumpForce = 8.0f;
    bool jumping = false;
    public GameObject bullet;
    public bool canShoot;
    public float timeBetweenShots = 1;
    private float timeUntilNextShot;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && jumping == false)
        {
            jumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (TouchController.movingUp)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Debug.Log("Going up!");
        }
        if (Input.GetKey(KeyCode.Space))
        {

        }
        if (Time.time > timeUntilNextShot)
        {
            canShoot = true;
        }
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            canShoot = false;
            timeUntilNextShot = Time.time + timeBetweenShots;
            Instantiate(bullet, this.transform.position, this.transform.rotation);
        }
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                jumping = false;
            }
        }
    }
}