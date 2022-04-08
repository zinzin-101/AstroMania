using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAllScript : MonoBehaviour
{
	public Transform camera;
	private Transform plat_pos;
	public GameObject plat1;
	public GameObject plat2;


	void Start()
	{
		plat_pos = GetComponent<Transform>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		plat1.SetActive(false);
		plat2.SetActive(false);

		int rand_num = Random.Range(1,3);
		switch (rand_num)
        {
			case 1:
				plat1.SetActive(true);
				plat2.SetActive(false);
				break;
			case 2:
				plat2.SetActive(true);
				plat1.SetActive(false);
				break;
		}		
	}

	void Update()
	{
		if (plat_pos.position.y + 6 < camera.position.y)
		{
			relocate_();
		}
	}

	private void relocate_()
	{
		Vector3 new_pos = new Vector3();
		new_pos.x = Random.Range(-5f, 5f);
		new_pos.y = camera.position.y + Random.Range(5f, 5.5f);

		int rand_num = Random.Range(1, 3);
		switch (rand_num)
		{
			case 1:
				plat1.SetActive(true);
				plat2.SetActive(false);
				break;
			case 2:
				plat2.SetActive(true);
				plat1.SetActive(false);
				break;

		}

		plat_pos.position = new_pos;
	}
}