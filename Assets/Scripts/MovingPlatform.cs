using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	public float bounce = 12f;
	public Transform camera;
	private Transform plat_pos;

	public Transform pos1, pos2;
	private float velocity;
	public Transform start_pos;
	private Vector3 next_pos;

	public AudioSource jump_sound;

	public GameObject particles;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.relativeVelocity.y <= 0f)
		{
			Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
			if (rb != null)
			{
				Vector2 velocity = rb.velocity;
				velocity.y = bounce;
				rb.velocity = velocity;
				jump_sound.Play();
			}
			if (VisualEffectScript.visual_setting)
            {
				Vector3 part_pos = new Vector3();
				part_pos = transform.position;
				Instantiate(particles, part_pos, Quaternion.identity);
			}			
		}
	}

	void Start()
	{
		plat_pos = GetComponent<Transform>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		next_pos = start_pos.position;
		velocity = Random.Range(2f, 5f);

	}

	void LateUpdate()
	{
		if (plat_pos.position.y + 6 < camera.position.y)
		{
			Destroy(transform.parent.gameObject);
		}
	}

	void FixedUpdate()
    {
		if (transform.position == pos1.position)
        {
			next_pos = pos2.position;
        }

		if (transform.position == pos2.position)
        {
			next_pos = pos1.position;
        }

		transform.position = Vector3.MoveTowards(transform.position, next_pos, velocity * Time.deltaTime);
    }
}
