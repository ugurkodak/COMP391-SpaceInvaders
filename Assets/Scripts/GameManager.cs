using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerPrefab;
    public Transform alienPrefab;

    Camera mainCamera;
    AudioSource aSource;
    Material background;

    public int score = 0;
    List<Transform> aliens = new List<Transform>();
    bool batchActive = false;

    void Start()
    {
        Instantiate(playerPrefab, new Vector3(0, 0, -0.5f), Quaternion.identity);
        mainCamera = transform.Find("Main Camera").GetComponent<Camera>();
        background = mainCamera.transform.Find("Space Background").GetComponent<MeshRenderer>().material;
        StartCoroutine(moveBackground());
        aSource = GetComponent<AudioSource>();
    }

    void Update ()
    {
        //mainCamera.transform.position = mainCamera.transform.position + transform.up * 0.001f;
        //Level 1
        if (!batchActive && score < 100)
        {
            StartCoroutine(sendBatch1());
            batchActive = true;
        }
        if (aliens.Count <= 0)
        {
            batchActive = false;
        }

        aliens.RemoveAll(alien => alien == null);
    }

    IEnumerator sendBatch1()
    {
        aSource.Play();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                aliens.Add(Instantiate(alienPrefab, new Vector3(-0.7f + j * 0.15f, -2f, 0.4f + i * 0.15f), Quaternion.identity));
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator moveBackground()
    {
        while (true)
        {
            background.mainTextureOffset += Vector2.up * 0.0005f;
            yield return null;
        }
    }
}