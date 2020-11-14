using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ScoreManager scoreManager;
    public AudioSource bgSound, deathSound;

    private Vector3 playerStartPt, groundGenStartpt;

    public GroundGenrator groundGenerator;
    public GameObject largeG, MediumG;

    public GameObject gameOverScreen;
    void Start()
    {
        playerStartPt = player.transform.position;
        groundGenStartpt = groundGenerator.transform.position;
        gameOverScreen.SetActive(false);
    }
    

    public void quit() {
        Application.Quit();
    }
    
    public void gameOver() {
        player.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        scoreManager.isScoreInc = false;
        bgSound.Stop();
        deathSound.Play();
    }

    public void restart () {
            GroundDestroyer[] destroyers = FindObjectsOfType<GroundDestroyer>();
            for (int i = 0; i<destroyers.Length; i++) {
                destroyers[i].gameObject.SetActive(false);
            }
            largeG.SetActive(true);
            MediumG.SetActive(true);
            player.transform.position = playerStartPt;
            groundGenerator.transform.position = groundGenStartpt;
            gameOverScreen.SetActive(false);
            player.gameObject.SetActive(true);
            // bgSound.Play();
            scoreManager.score = 0;
            scoreManager.isScoreInc = true;
    }
}
