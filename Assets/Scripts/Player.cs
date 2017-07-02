using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform bulletPrefab;  
    public float power = 0.05f;
    public static int score = 0;
    
    Rigidbody rBody;

    void Awake()
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
    }
	
	void Update ()
    {
        //Shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
	    if (GameManager.state == 2)
	    {
		Time.timeScale = 1;
		Application.LoadLevel(0);
	    }
	    //Start level 1
	    GameManager.state = 1;
	    
            Instantiate(bulletPrefab, transform.position + Vector3.forward * 0.1f, Quaternion.identity);
        }
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
	    GameManager.state = 2;
        }
    }
}
