using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerPrefab;
    public Transform alienPrefab;

    AudioSource aSource;

    public int score = 0;
    List<Transform> aliens = new List<Transform>();
    bool batchActive = false;

    void Start()
    {
        Instantiate(playerPrefab, new Vector3(0, 0, -0.5f), Quaternion.identity);
        aSource = GetComponent<AudioSource>();
    }

    void Update ()
    {
        //Level 1
        if (!batchActive && score < 100)
        {
            aSource.Play();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    aliens.Add(Instantiate(alienPrefab, new Vector3(-0.7f + i * 0.15f, -2f, 0.5f + j * 0.15f), Quaternion.identity));
                }
            }
            batchActive = true;
        }
        if (aliens.Count <= 0)
        {
            batchActive = false;
        }

        aliens.RemoveAll(alien => alien == null);
    }
}
