using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject tutorial_page;
    public GameObject main_menu_;

    void Start()
    {
        tutorial_page.SetActive(false);
    }

    public void tutorial_open()
    {
        tutorial_page.SetActive(true);
        main_menu_.SetActive(false);
    }

    public void tutorial_off()
    {
        main_menu_.SetActive(true);
        tutorial_page.SetActive(false);
    }
}
