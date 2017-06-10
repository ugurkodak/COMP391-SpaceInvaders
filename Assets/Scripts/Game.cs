using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public Transform playerPrefab;
    public Transform alien1Prefab;

    public int level = 0;
    bool levelEnded = true;
    List<Transform> aliens = new List<Transform>();

    //Level 0 variables
    const float moveLength = 0.1f;
    const float movePeriod = 1;
    int lineTurn = 0;
    float lineTimer = 0;

    void Start ()
    {
        //Instantiate player
        Instantiate(playerPrefab, new Vector3(0, -0.4f, 2), transform.rotation);     
    }

	void Update ()
    {
        //Original level
        if (level == 0)
        {
            const int rowLenght = 3;
            const int columnLength = 8;

            //Instantiate level 0
            if (levelEnded)
            {
                levelEnded = false;
                for (int row = 0; row < rowLenght; row++)
                {
                    for (int column = 0; column < columnLength; column++)
                    {
                        aliens.Add(Instantiate(alien1Prefab, new Vector3(column * 0.5f - 1.75f, row * 0.5f + 1.5f, 2), Quaternion.identity));
                    }
                }
            }
            //Play level 0
            else
            {
                if (lineTimer >= movePeriod)
                {
                    for (int column = 0; column < columnLength; column++)
                    {
                        aliens[column + columnLength * lineTurn].Translate(moveLength, 0, 0);
                    }
                    lineTurn++;
                    if (lineTurn >= rowLenght)
                    {
                        lineTurn = 0;
                    }
                    lineTimer = 0;
                }
                lineTimer += Time.deltaTime;
            }
        }
	}
}
