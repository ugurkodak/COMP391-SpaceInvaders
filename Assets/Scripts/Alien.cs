using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    bool movingRight = true;
    bool movingForward = false;
    bool touching = false;
    int touchingCounter = 0;
    int collisionCounter = 0;

    public float speed = 0.5f;

	void Start ()
    {
    }

	void Update ()
    {
        if (movingRight)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (transform.position.x >= 2f)
            {
                collisionCounter++;
                movingRight = false;
            }
        }
        else if (!movingRight)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (transform.position.x <= -2f)
            {
                collisionCounter++;
                movingRight = true;
            }
        }
        if (movingForward)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);

            if (transform.position.y > 0.5)
            {
                movingForward = false;
            }

            if (transform.position.y < -1f)
            {
                DestroyObject(gameObject);
            }
        }

        if (touching)
        {
            touchingCounter++;
        }
        else
        {
            touchingCounter = 0;
        }
        if (touchingCounter > 2)
        {
            if (Random.value > 0.5f)
            {
                transform.Translate(0.1f, 0, 0);
            }
            else
            {
                transform.Translate(-0.1f, 0, 0);
            }
            touchingCounter = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        touching = true;

        collisionCounter++;
        if (collisionCounter > 9)
        {
            movingForward = true;
        }

        movingRight = !movingRight;
    }

    void OnTriggerExit(Collider other)
    {
        touching = false;
    }
}
