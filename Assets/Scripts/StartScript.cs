using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public GameObject main_menu;
    public GameObject score;
    public GameObject tries;
    public GameObject effect_button_text, trail;
    public GameObject player;
    private Rigidbody2D rb;
    private Text effect_text;

    void Awake()
    {
        Time.timeScale = 0;
        rb = player.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        effect_text = effect_button_text.GetComponent<Text>();
        Time.timeScale = 0;
        score.SetActive(false);
        tries.SetActive(false);
        main_menu.SetActive(true);
    }

    public void Start_Game()
    {
        rb.WakeUp();
        Time.timeScale = 1;
        score.SetActive(true);
        tries.SetActive(true);
        switch (effect_text.text)
        {
            case "ON":
                VisualEffectScript.visual_setting = true;
                break;
            case "OFF":
                VisualEffectScript.visual_setting = false;
                break;
        }
        if (VisualEffectScript.visual_setting)
        {
            trail.SetActive(true);
        }
        else
        {
            trail.SetActive(false);
        }
            main_menu.SetActive(false);        
    }
}

