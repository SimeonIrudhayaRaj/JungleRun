using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private float coinPoints = 15f;
    private AudioSource coinSound;
    private ScoreManager scoreManager;
    void Start()
    {
        coinSound = GameObject.Find("CoinPickSound").GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            gameObject.SetActive(false);
            if (coinSound.isPlaying) {
                coinSound.Stop();
            }
            coinSound.Play();
            scoreManager.score += coinPoints;
        }
    }
}
