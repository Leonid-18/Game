using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score_2 : MonoBehaviour
{

     Text score_text;
    public static int scoreAmount_2;
    private int old_score;
    private int score;
    private void Awake()
    {
        score_text = GetComponent<Text>();
        scoreAmount_2 = 0;
     

    }
    // Use this for initialization
    void Start()
    { 
        
        old_score = PlayerPrefs.GetInt("player_score");

    }
    private void Update()
    {
        score = scoreAmount_2 + old_score;
        score_text.text = "" + score;

    }
}
