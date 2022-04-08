using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public GameObject credit_page;
    public GameObject main_menu_;

    void Start()
    {
        credit_page.SetActive(false);
    }

    public void credit_open()
    {
        credit_page.SetActive(true);
        main_menu_.SetActive(false);
    }

    public void credit_off()
    {
        main_menu_.SetActive(true);
        credit_page.SetActive(false);
    }
}
