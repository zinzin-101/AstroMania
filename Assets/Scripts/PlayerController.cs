using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float move_speed = 10f;
    public Rigidbody2D rb;
    
    float move_x;

    // call during loadtime
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move_x = Input.GetAxis("Horizontal") * move_speed;
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = move_x;
        rb.velocity = velocity;
    }
}
