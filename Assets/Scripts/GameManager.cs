using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform playerPrefab;
    public Transform alienPrefab;
    public static int state = 0; //0(Init), 1(Run), 2(Game Over)

    Transform canvas;
    Text textInstructions;
    Text textScore;
    Camera mainCamera;
    Material background;
    List<Transform> aliens = new List<Transform>();
    bool batchActive = false;

    void Awake()
    {
        Instantiate(playerPrefab, new Vector3(0, 0, -0.5f), Quaternion.identity);
        mainCamera = transform.Find("Main Camera").GetComponent<Camera>();
        background = mainCamera.transform.Find("Space Background").GetComponent<MeshRenderer>().material;
	canvas = transform.Find("Canvas");
	textInstructions = canvas.transform.Find("textInstructions").GetComponent<Text>();
	textScore = canvas.transform.Find("textScore").GetComponent<Text>();
        StartCoroutine(moveBackground());
    }

    void Update ()
    {
	if (state == 1)
	{ 
	    //Level 1
	    if (!batchActive)
	    {
		textInstructions.text = "";
		StartCoroutine(sendAliens());
		batchActive = true;
	    }

	    if (aliens.Count <= 0)
	    {
		batchActive = false;
	    }
	    aliens.RemoveAll(alien => alien == null);

	    textScore.text = "SCORE: " + Player.score;   
	}
	else if (state == 2)
	{   
	    Time.timeScale = 0;
	    // batchActive = false;
	    // aliens.Clear();
	    textInstructions.text = "GAME OVER\nPress SPACE to RESTART\nPress ESCAPE to QUIT";
	}
    }

    IEnumerator sendAliens()
    {
    
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                aliens.Add(Instantiate(alienPrefab, new Vector3(-0.9f + j * 0.2f, -2f, 0.3f + i * 0.1f), Quaternion.identity));
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
