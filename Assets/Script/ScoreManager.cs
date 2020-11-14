using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float pointsPerSecond;

    public Text scoreText, hiScoreText;

    public float score, hiScore;

    public bool isScoreInc = true;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HiScore")) {
            hiScore =  PlayerPrefs.GetFloat("HiScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isScoreInc) {
            return;
        }
        score += pointsPerSecond * Time.deltaTime;
        if (score >= hiScore) {
            hiScore = score;
            PlayerPrefs.SetFloat("HiScore", hiScore);
        }

        scoreText.text = Mathf.Round(score).ToString();
        hiScoreText.text = Mathf.Round(hiScore).ToString();
    }
}
