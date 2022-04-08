using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizScript : MonoBehaviour
{
	public Transform camera;
	private Transform plat_pos;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.relativeVelocity.y <= 0f)
		{
			Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
			if (rb != null)
			{
				Time.timeScale = 0.001f;
				QuizManager.activate = true;
				Destroy(gameObject);
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
		if (plat_pos.position.y + 8 < camera.position.y)
		{
			Destroy(gameObject);
		}
	}
}
