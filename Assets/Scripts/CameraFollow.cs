using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public GameObject Game_over;
    public static bool game_over_;
    public AudioSource[] death_sound;
    private bool is_death = false;

    void Start()
    {
        game_over_ = false;
    }

    private void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            Vector3 new_pos = new Vector3(transform.position.x, target.position.y, transform.position.z);
                transform.position = new_pos;
                ScoreScript.score_value += 1;
        }

        if (target.position.y + 10 < transform.position.y)
        {
            if (is_death == false)
            {
                int rand_death_sound;
                AudioSource death_s;

                rand_death_sound = Random.Range(0, 2);
                death_s = death_sound[rand_death_sound];
                death_s.Play();
                is_death = true;
            }
            
            Game_over.SetActive(true);
        }

        if (game_over_ == true)
        {
            Time.timeScale = 0;
            Game_over.SetActive(true);
        }
    }
}
