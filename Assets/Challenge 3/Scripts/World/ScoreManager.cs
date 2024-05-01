using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //  Set ScoreWidget as a Singleton where get is public and set is private
    public static ScoreManager Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI scoreText;		//	Reference to the text in TMProGGUI
    private int score = 0;

   private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() {
        UpdateScore();
    }

    private void UpdateScore() {
        scoreText.text = "$ " + score;
    }

    public void IncrementScore() {
        score++;
        UpdateScore();
    }

    public void DecrementScore() {
        if (score > 0) {
            score--;
            UpdateScore();
        }
    }


    public int GetScore() {
        return score;
    }

    public void ResetScore() {
        score = 0;
        UpdateScore();
    }


}
