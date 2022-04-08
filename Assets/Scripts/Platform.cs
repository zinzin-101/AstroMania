using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	public float bounce = 10f;
	public Transform camera;
	private Transform plat_pos;
	public AudioSource jump_sound;
	public GameObject plat1_particle;

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
				Instantiate(plat1_particle, part_pos, Quaternion.identity);
			}			
		}
	}

	void Start()
    {
		plat_pos = GetComponent<Transform>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").transform;

	}

	void LateUpdate()
    {
		if (plat_pos.position.y + 6 < camera.position.y)
        {
			Destroy(gameObject);
        }
    }
}