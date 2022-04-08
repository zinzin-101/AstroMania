using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualEffectScript : MonoBehaviour
{
    public static bool visual_setting = true;
    public static string cate;
    public GameObject button_text, cate_button;
    private Text text_, cate_text_;

    void Awake()
    {
        cate_text_ = cate_button.GetComponent<Text>();
        cate = "all";
        cate_text_.text = "ALL";
    }

    void Start()
    {
        text_ = button_text.GetComponent<Text>();  
        switch (visual_setting)
        {
            case true:
                text_.text = "ON";
                break;
            case false:
                text_.text = "OFF";
                break;
        }
    }

    public void visual_switch()
    {
        switch (text_.text)
        {
            case "ON":
                visual_setting = false;
                text_.text = "OFF";
                break;
            case "OFF":
                visual_setting = true;
                text_.text = "ON";
                break;
        }
    }

    public void cate_switch()
    {
        switch (cate)
        {
            case "all":
                cate_text_.text = "MATH";
                cate = "math";
                break;
            case "math":
                cate_text_.text = "PHYS";
                cate = "phys";
                break;
            case "phys":
                cate_text_.text = "CHEM";
                cate = "chem";
                break;
            case "chem":
                cate_text_.text = "BIO";
                cate = "bio";
                break;
            case "bio":
                cate_text_.text = "ALL";
                cate = "all";
                break;
        }
    }
}