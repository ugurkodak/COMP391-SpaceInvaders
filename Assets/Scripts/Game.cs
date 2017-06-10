using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public Transform playerPrefab;
    public Transform alien1Prefab;

	void Start ()
    {
        //Place player
        Instantiate(playerPrefab, new Vector3(0, -0.4f, 2), transform.rotation);

        //Place aliens
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                Instantiate(alien1Prefab , new Vector3(x * 0.5f - 1.75f, y * 0.5f + 1.5f, 2), transform.rotation);
            }
        }
    }

	void Update ()
    {
		
	}
}
