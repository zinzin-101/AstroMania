using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptV3 : MonoBehaviour
{
	public Transform camera;
	private Transform plat_pos;

	public float max_speed;
	public Transform pos1, pos2;
	private float velocity;
	public Transform start_pos;
	private Vector3 next_pos;
	private string name;

	public AudioSource[] enemy1_hit;
	public AudioSource enemy2_hit;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{
			if (QuizManager.hit_)
            {
				QuizManager.hit_ = false;
				switch (name)
				{
					case "enemy1":
						int rand_audio;
						AudioSource enemy1_sound;
						rand_audio = Random.Range(0, 2);
						enemy1_sound = enemy1_hit[rand_audio];
						enemy1_sound.Play();
						break;
					case "enemy2":
						enemy2_hit.Play();
						break;
				}
				int rand_num = Random.Range(-5, 4);
				if (rand_num >= -1)
				{
					Time.timeScale = 0.001f;
					QuizManager.w_activate = true;
					Destroy(gameObject);
				}
				else
				{
					Time.timeScale = 0;
					CameraFollow.game_over_ = true;
				}
			}						
		}
	}

	void Start()
	{
		plat_pos = GetComponent<Transform>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		name = GetComponent<SpriteRenderer>().sprite.name;

		next_pos = start_pos.position;
		velocity = Random.Range(2f, max_speed);

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

