using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rBody;
    
    public float speed = 50f;
    public float lifetime = 2f;

    void Awake()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rBody.AddForce(transform.forward * speed);
    }

    void FixedUpdate()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
