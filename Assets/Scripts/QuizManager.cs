using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
    public GameObject doodle;
    private Transform t_doodle;
    public GameObject[] all_question, chem_qs, bio_qs, phys_qs, math_qs, w_questions;
    private GameObject[] current_qs;
    public Text[] w_answers;
    string w_ans;
    int rand_question, rand_w_question;
    public static bool activate, w_activate;
    public GameObject tries;
    public int tries_value = 3;
    public static bool hit_;
    private string input_;

    public AudioSource correct, boost_effect, incorrect;
    public AudioSource[] break_effect;

    public float bounce = 10f;
    public float boost = 20f;
    public float normal = 10f;

    public GameObject boost_trail;

    public GameObject timer;
    public float time_left = 16f;
    private bool timer_activate;
    private float time_remaining;
    private float _time_remaining;

    public GameObject cor_particle, in_particle;

    Text tries_text;
    Text timer_text;

    void Awake()
    {
        hit_ = true;
        activate = false;
        w_activate = false;
        timer_activate = false;
        time_remaining = time_left;
    }

    public void Start()
    {
        timer.SetActive(false);
        boost_trail.SetActive(false);
        tries_text = tries.GetComponent<Text>();
        timer_text = timer.GetComponent<Text>();
        t_doodle = doodle.GetComponent<Transform>().transform;      
    }

    void Update()
    {
        if (activate)
        {
            quiz_();                                 
        }
        else if (w_activate)
        {
            w_quiz();
        }

        if (timer_activate == true)
        {          
            if (time_remaining > 0)
            {
                time_remaining -= 1000 * Time.deltaTime;
            }
            else
            {
                incorrect_answer();                
            }
        }
        timer_text.text = "" + time_remaining;
    }

    void FixedUpdate()
    {
        tries_text.text = "Quiz tries left: " + tries_value;
        if (tries_value <= 0)
        {
            CameraFollow.game_over_ = true;
        }
    }

    void LateUpdate()
    {
        switch (VisualEffectScript.cate)
        {
            case "all":
                current_qs = all_question;
                break;
            case "math":
                current_qs = math_qs;
                break;
            case "phys":
                current_qs = phys_qs;
                break;
            case "chem":
                current_qs = chem_qs;
                break;
            case "bio":
                current_qs = bio_qs;
                break;
        }
    }

    int ArrSize(GameObject[] array_)
    {
        int size_ = 0;
        foreach(GameObject q_ in array_)
        {
            size_++;
        }
        return size_;
    }

    void quiz_()
    {
        activate = false;
        time_remaining = time_left;
        int qs_size = ArrSize(current_qs);
        rand_question = Random.Range(0, qs_size);
        current_qs[rand_question].SetActive(true);
        timer.SetActive(true);
        timer_activate = true;
    }

    void w_quiz()
    {
        w_activate = false;
        time_remaining = time_left;
        rand_w_question = Random.Range(0, 11);
        w_questions[rand_w_question].SetActive(true);
        w_ans = w_answers[rand_w_question].text;
        timer.SetActive(true);
        timer_activate = true;
    }

    private void break_play()
    {
        int rand_sound = Random.Range(0, 2);
        AudioSource break_sound = break_effect[rand_sound];
        break_sound.Play();
    }

    public void correct_answer()
    {
        current_qs[rand_question].SetActive(false);
        correct.Play();
        Rigidbody2D rb = doodle.GetComponent<Rigidbody2D>();        
        Vector2 velocity = rb.velocity;
        velocity.y = boost;
        rb.velocity = velocity;
        Time.timeScale = 1;
        timer.SetActive(false);
        timer_activate = false;
        ScoreScript.score_value += 1500;
        boost_effect.Play();        
        if (VisualEffectScript.visual_setting)
        {
            boost_trail.SetActive(true);
            StartCoroutine(b_trail_play());
            effect_player(cor_particle);
        }
    }

    public void incorrect_answer()
    {
        incorrect.Play();
        current_qs[rand_question].SetActive(false);
        Rigidbody2D rb = doodle.GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        velocity.y = bounce;
        rb.velocity = velocity;
        Time.timeScale = 1;
        tries_value -= 1;
        timer.SetActive(false);
        timer_activate = false;
        break_play();
        if (VisualEffectScript.visual_setting)
        {
            effect_player(in_particle);
        }           
    }

    public void ReadStringInput(string s)
    {
        input_ = s;
    }

    public void check_ans()
    {
        if (input_ == w_ans)
        {
            w_cor_ans();
        }
        else
        {
            w_in_ans();
        }
    }

    public void w_cor_ans()
    {
        w_questions[rand_w_question].SetActive(false);
        Rigidbody2D rb = doodle.GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        velocity.y = normal;
        rb.velocity = velocity;
        Time.timeScale = 1;
        timer.SetActive(false);
        timer_activate = false;
        hit_ = true;
    }

    public void w_in_ans()
    {
        w_questions[rand_w_question].SetActive(false);
        timer_activate = false;
        Time.timeScale = 0;
        CameraFollow.game_over_ = true;
    }

    IEnumerator b_trail_play()
    {
        yield return new WaitForSeconds(1);
        boost_trail.SetActive(false);
    }

    void effect_player(GameObject prefab)
    {
        Vector3 part_pos = new Vector3();
        part_pos = t_doodle.position;
        Instantiate(prefab, part_pos, Quaternion.identity);
    }
}