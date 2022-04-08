using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public GameObject camera;
    private Transform t_camera;
    public GameObject bg1;
    public GameObject bg2;
    private Transform t_bg1;
    private Transform t_bg2;

    void Start()
    {
        t_camera = camera.GetComponent<Transform>();
        t_bg1 = bg1.GetComponent<Transform>();
        t_bg2 = bg2.GetComponent<Transform>();
        Vector3 pos_bg1 = new Vector3();
        Vector3 pos_bg2 = new Vector3();
        pos_bg1.x = 0f;
        pos_bg1.y = 0f;
        pos_bg2.x = 0f;
        pos_bg2.y = 10.75f;

        t_bg1.position = pos_bg1;
        t_bg2.position = pos_bg2;
    }

    public void relocate_(Transform object_)
    {
        Vector3 new_pos = new Vector3();
        new_pos.x = 0f;
        new_pos.y = t_camera.position.y + 10.75f;
        object_.position = new_pos;
    }

    void FixedUpdate()
    {
        if (t_bg1.position.y <= t_camera.position.y - 10.36f)
        {
            relocate_(t_bg1);
        }

        if (t_bg2.position.y <= t_camera.position.y - 10.36f)
        {
            relocate_(t_bg2);
        }
    }
}