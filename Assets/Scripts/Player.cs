using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4f;
	void Start ()
    {

	}
	
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Fire!");
        }

        if (transform.position.x > 2f)
        {
            transform.position = new Vector3(2f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -2f)
        {
            transform.position = new Vector3(-2f, transform.position.y, transform.position.z);
        }
    }
}
