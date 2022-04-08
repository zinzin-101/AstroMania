using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text score;
    public Text cate_;

    void Update()
    {
        score.text = "Score: " + ScoreScript.real_score;
    }

    void LateUpdate()
    {
        switch (VisualEffectScript.cate)
        {
            case "all":
                cate_.text = "Category: ALL";
                break;
            case "math":
                cate_.text = "Category: MATH";
                break;
            case "phys":
                cate_.text = "Category: PHYS";
                break;
            case "chem":
                cate_.text = "Category: CHEM";
                break;
            case "bio":
                cate_.text = "Category: BIO";
                break;
        }
    }
}
