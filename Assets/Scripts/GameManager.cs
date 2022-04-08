using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject plat_prefab;
    public GameObject Break_plat_prefab;
    public GameObject moving_platform_prefab;
    public GameObject quiz_platform_prefab;
    public GameObject enemy_prefab;

    public int plat_count = 100;
    public int b_plat_count = 50;
    public int m_plat_count = 25;
    public int q_plat_count = 5;
    private int e_count;

    public Transform target;
    private int plat_gen_coord = 200;
    private int plat_sgen_coord = 180;

    // generating platform after starting
    void Start()
    {
        Vector3 spawn_pos = new Vector3();
        Vector3 s_spawn_pos = new Vector3();
        Vector3 m_spawn_pos = new Vector3();
        Vector3 q_spawn_pos = new Vector3();

        // normal platform
        for (int i = 0; i < plat_count; i++)
        {
            spawn_pos.y += Random.Range(2.5f, 2f);
            spawn_pos.x = Random.Range(-5f, 5f);
            Instantiate(plat_prefab, spawn_pos, Quaternion.identity);
        }

        // breakable platform
        for (int i = 0; i < b_plat_count; i++)
        {
            s_spawn_pos.y += Random.Range(5f, 3f);
            s_spawn_pos.x = Random.Range(-5f, 5f);
            Instantiate(Break_plat_prefab, s_spawn_pos, Quaternion.identity);
        }

        // moving platform
        for (int i = 0; i < m_plat_count; i++)
        {
            m_spawn_pos.y += Random.Range(10f, 6f);
            m_spawn_pos.x = Random.Range(-5f, 5f);
            Instantiate(moving_platform_prefab, m_spawn_pos, Quaternion.identity);
        }

        // quiz platform
        for (int i = 0; i < m_plat_count; i++)
        {
            q_spawn_pos.y += Random.Range(40f, 20f);
            q_spawn_pos.x = Random.Range(-5f, 5f);
            Instantiate(quiz_platform_prefab, q_spawn_pos, Quaternion.identity);
        }
    }

    void Update()
    {
        // regenerating platform after exceeding certain y coord 
        if (target.position.y > plat_sgen_coord)
        {
            Vector3 spawn_pos = new Vector3();
            Vector3 s_spawn_pos = new Vector3();
            Vector3 m_spawn_pos = new Vector3();
            Vector3 q_spawn_pos = new Vector3();
            Vector3 e_spawn_pos = new Vector3();

            spawn_pos.y = plat_gen_coord;
            s_spawn_pos.y = plat_gen_coord;
            m_spawn_pos.y = plat_gen_coord;
            q_spawn_pos.y = plat_gen_coord;
            e_spawn_pos.y = plat_gen_coord;

            e_count = 4;

            // normal platform
            for (int i = 0; i < plat_count; i++)
            {
                spawn_pos.y += Random.Range(2.5f, 2f);
                spawn_pos.x = Random.Range(-5f, 5f);
                Instantiate(plat_prefab, spawn_pos, Quaternion.identity);
            }

            // breakable platform
            for (int i = 0; i < b_plat_count; i++)
            {
                s_spawn_pos.y += Random.Range(5f, 3f);
                s_spawn_pos.x = Random.Range(-5f, 5f);
                Instantiate(Break_plat_prefab, s_spawn_pos, Quaternion.identity);
            }

            // moving platform
            for (int i = 0; i < m_plat_count; i++)
            {
                m_spawn_pos.y += Random.Range(12f, 8f);
                m_spawn_pos.x = Random.Range(-5f, 5f);
                Instantiate(moving_platform_prefab, m_spawn_pos, Quaternion.identity);
            }

            // quiz platform
            for (int i = 0; i < m_plat_count; i++)
            {
                q_spawn_pos.y += Random.Range(40f, 20f);
                q_spawn_pos.x = Random.Range(-5f, 5f);
                Instantiate(quiz_platform_prefab, q_spawn_pos, Quaternion.identity);
            }

            // enemy intensity
            if (target.position.y < 700)
            {
                if (target.position.y >= 360)
                {
                    e_count = 6;
                }
            }
            else if (target.position.y < 900)
            {
                if (target.position.y >= 760)
                {

                    e_count = 8;
                }

            }
            else if (target.position.y >= 960)
            {
                e_count = 10;
            }
            // enemy
            for (int i = 0; i < e_count; i++)
            {
                e_spawn_pos.y += Random.Range(30f, 15f);
                e_spawn_pos.x = Random.Range(-5f, 5f);
                Instantiate(enemy_prefab, e_spawn_pos, Quaternion.identity);
            }

            plat_gen_coord += 200;
            plat_sgen_coord = plat_gen_coord - 20;
        }
    }
}
