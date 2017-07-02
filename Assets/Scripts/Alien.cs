using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    Rigidbody rBody;
    
    public Transform bulletPrefab;
    public float power = 0.05f;
    
    Transform player;

    void Awake()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        StartCoroutine(takePosition());
        StartCoroutine(moveToPlayerBase());
        StartCoroutine(shootBullets());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
	    Player.score++;
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
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }

    IEnumerator moveToPlayerBase()
    {
        float maneuver = 0.2f;
        while (transform.position.z > player.position.z + 0.15f)
        {
            rBody.velocity = new Vector3(maneuver, rBody.velocity.y, -power);
            maneuver = -maneuver;
            yield return new WaitForSeconds(2f);
        }
        print("Game Over");
    }

    IEnumerator shootBullets()
    {
	yield return new WaitForSeconds(2);
        while (true)
        {  
            transform.LookAt(player.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    Instantiate(bulletPrefab, transform.position + transform.forward * 0.08f, Quaternion.identity).LookAt(player.position);
                }
            }
	    yield return new WaitForSeconds(1);
        }
    }
}
