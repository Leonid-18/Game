using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int scoreAmount;
    Text scoreText;
    private void Awake()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
    }
    private void Update()
    {
        scoreText.text = ""+scoreAmount;
        PlayerPrefs.SetInt("player_score", scoreAmount);
    }

}
