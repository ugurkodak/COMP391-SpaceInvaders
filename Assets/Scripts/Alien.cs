using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    Rigidbody rBody;

    public float power = 0.05f;

    void Start ()
    {
        rBody = GetComponent<Rigidbody>();
        StartCoroutine(takePosition());
        StartCoroutine(moveToPlayerBase());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator takePosition()
    {
        while (transform.position.y < -0.001f)
        {
            transform.position = transform.position + transform.up * 0.1f * Mathf.Abs(transform.position.y); 
            yield return null;
        }
        yield return null;
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        print("Took position");
    }

    IEnumerator moveToPlayerBase()
    {
        float maneuver = 0.2f;
        while (transform.position.z > GameObject.FindGameObjectsWithTag("Player")[0].transform.position.z + 0.15f)
        {
            rBody.velocity = new Vector3(maneuver, rBody.velocity.y, -power);
            maneuver = -maneuver;
            yield return new WaitForSeconds(2f);
        }
        print("Game Over");
    }
}
