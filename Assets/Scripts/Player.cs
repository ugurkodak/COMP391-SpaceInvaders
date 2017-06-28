using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rBody;
    public Transform bulletPrefab;
    public float power = 0.05f;

	void Start ()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Movement input
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rBody.velocity += transform.right * power;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rBody.velocity += -transform.right * power;
        }
        //Shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + Vector3.forward * 0.1f, Quaternion.identity);
        }
    }
	
	void Update ()
    {
        //Player boundaries
        if (transform.position.x > 0.8f)
        {
            transform.position = new Vector3(0.8f, transform.position.y, transform.position.z);
            rBody.velocity = Vector3.zero;
        }
        if (transform.position.x < -0.8f)
        {
            transform.position = new Vector3(-0.8f, transform.position.y, transform.position.z);
            rBody.velocity = Vector3.zero;
        }
    }
}
