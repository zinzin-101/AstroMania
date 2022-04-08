using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
	public Transform camera;
	private Transform plat_pos;
	public GameObject doodle;

	void Start()
	{
		plat_pos = GetComponent<Transform>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		doodle = GameObject.FindGameObjectWithTag("Player");
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{
			Time.timeScale = 0;
			doodle.SetActive(false);
			CameraFollow.game_over_ = true;
		}
	}

	void LateUpdate()
	{
		if (plat_pos.position.y + 8 < camera.position.y)
		{
			Destroy(gameObject);
		}
	}
}
