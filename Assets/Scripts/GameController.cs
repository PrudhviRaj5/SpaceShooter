using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject hazard1, hazard2, hazard3, hazard4;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait, startWait, waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private int score;
	private bool gameOver;
	private bool restart;

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves());
	}
	void Update()
	{
		if (restart) 
		{
			if (Input.GetKeyDown(KeyCode.R))
				Application.LoadLevel (Application.loadedLevel);
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds(startWait);
		while(true)
		{
			for (int i=0; i<hazardCount; i++) 
			{
				Vector3 spawnPosition1 = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation1 = Quaternion.identity;
				Instantiate (hazard1, spawnPosition1, spawnRotation1);
				yield return new WaitForSeconds(spawnWait);
				Vector3 spawnPosition2 = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation2 = Quaternion.identity;
				Instantiate (hazard2, spawnPosition2, spawnRotation2);
				yield return new WaitForSeconds(spawnWait);
				Vector3 spawnPosition3 = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation3 = Quaternion.identity;
				Instantiate (hazard3, spawnPosition3, spawnRotation3);
				yield return new WaitForSeconds(spawnWait + 0.1f);

				if (i%4 == 0)
				{
					Vector3 spawnPosition4 = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Quaternion spawnRotation4 = Quaternion.identity;
					Instantiate (hazard4, spawnPosition4, spawnRotation4);
					yield return new WaitForSeconds(spawnWait + 0.1f);
				}
				if (gameOver)
				{
					restartText.text = "Press 'R' for Restart";
					restart = true;
					break;
				}
			}
			if (gameOver)
			{
				restartText.text = "Press 'R' or Restart";
				restart = true;
				break;
			}
			yield return new WaitForSeconds(waveWait);
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score " + score;
	}
	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}
}
