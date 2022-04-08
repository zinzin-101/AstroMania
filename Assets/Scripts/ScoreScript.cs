using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int score_value = 0;
    public static int real_score;
    private float real_score_;
    Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        real_score_ = score_value / 10f;
        real_score = Mathf.RoundToInt(real_score_);
        score.text = "Score: " + real_score;
    }
}