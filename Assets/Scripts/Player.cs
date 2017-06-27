using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4f;

    public Transform bulletPrefab;
    Transform bullet;
    bool bulletActive = false;
    float bulletTimer = 2f;

	void Start ()
    {

	}
	
	void Update ()
    {
        //Movement input
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        //Shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletActive = true;
        }
        if (bulletActive)
        {
            if (bulletTimer >= 2f)
            {
                bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Debug.Log("PLAYER: " + transform.position);
                Debug.Log("Bullet: " + bullet.position);

            }
            bullet.Translate(0, Time.deltaTime * 2f, 0);
            bulletTimer -= Time.deltaTime;
            if (bulletTimer <= 0)
            {
                bulletActive = false;
                bulletTimer = 2f;
                Destroy(bullet.gameObject);
            }
        }

        //Player boundaries
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
