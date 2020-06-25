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
    // Start is called before the first frame update
    void Start()
    {
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
        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumping = false;
        }
    }
}