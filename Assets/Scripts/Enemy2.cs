using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Enemy2 : NPC {

    SecondEnemyE enemyTwo;
    public float uniDist = 5.0f;

    // Use this for initialization
    void Start()
    {
        enemyTwo.sEnemyHealth = 5;
        StartCoroutine(MovimientoEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (estado)
        {
            case behaviour.idle:
                speed = 0;
                Moving();
                break;

            case behaviour.moving:
                speed = 2.0f;
                Moving();
                break;

            case behaviour.chasing:
                speed = 3.0f;
                Moving();
                break;
        }

        buscar();

        if (target)
        {
            Vector3 myVector = target.transform.position - transform.position;

            float distanceToPlayer = myVector.magnitude;

            if (distanceToPlayer < uniDist)
            {
                estado = behaviour.chasing;
                transform.position += Vector3.Normalize(target.transform.position - transform.position) * speed * Time.deltaTime;
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemyTwo.sEnemyHealth--;
            
            if (enemyTwo.sEnemyHealth == 0)
            {
                Destroy(gameObject);
                FindObjectOfType<Manager>().contE2--;
            }
        }
    }

    public float distPlayer;
    public GameObject target;

    void buscar()
    {
        GameObject[] AllGameObjects = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject go in AllGameObjects)
        {
       
            if (go.GetComponent<Player>())
            {
                float distancia = Vector3.Distance(go.transform.position, transform.position);
                distPlayer = distancia;
                if (distancia <= 60f)
                {
                    target = go;
                }
            }
        }
    }
}
