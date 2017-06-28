using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rBody;

    public float speed = 1f;
    public float lifetime = 2f;

    void Start ()
    {
        rBody = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        rBody.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
    }

    void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
