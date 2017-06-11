using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public Transform playerPrefab;
    public Transform alien1Prefab;

    const float horizontalEdge = 2f;
    const float verticalEdge = 0.2f;

    public int level = 0;
    bool levelEnded = true;
    List<Transform> aliens = new List<Transform>();

    //Level 0 variables
    const int rowLenght = 3;
    const int columnLength = 11;
    float movePeriod = 0.3f;
    float moveLength = 0.05f;
    int lineTurn = 0;
    float lineTimer = 0;
    bool movingForward = false;

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
            //Instantiate level 0
            if (levelEnded)
            {
                levelEnded = false;
                for (int row = 0; row < rowLenght; row++)
                {
                    for (int column = 0; column < columnLength; column++)
                    {
                        aliens.Add(Instantiate(alien1Prefab, new Vector3(column * 0.35f - 1.75f, row * 0.5f + 1.5f, 2), Quaternion.identity));
                    }
                }
            }
            //Play level 0
            else
            {
                //Alien movement
                if (lineTimer >= movePeriod)
                {
                    for (int column = 0; column < columnLength; column++)
                    {
                        if (movingForward)
                        {
                            aliens[column + columnLength * lineTurn].Translate(moveLength, -0.2f, 0);
                            if (lineTurn == rowLenght - 1 && column == columnLength - 1)
                            {
                                if (aliens[0].position.y < verticalEdge)
                                {
                                    movePeriod -= 0.05f;
                                }
                                else
                                {
                                    movingForward = false;
                                }
                            }
                        }
                        else
                        {
                            aliens[column + columnLength * lineTurn].Translate(moveLength, 0, 0);
                        }
                    }
                    if (lineTurn == rowLenght - 1 && aliens[rowLenght * columnLength - columnLength].position.x < -horizontalEdge)
                    {
                        moveLength = -moveLength;
                        movingForward = true;
                    }
                    else if (lineTurn == rowLenght - 1 && aliens[rowLenght * columnLength - 1].position.x > horizontalEdge)
                    {
                        moveLength = -moveLength;
                        movingForward = true;
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
