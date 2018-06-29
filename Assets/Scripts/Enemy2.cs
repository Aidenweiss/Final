using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

    SecondEnemyE enemyTwo;

    int dir;

    behaviour estado;

    int idle = 0;
    int moving;
    int chasing;

    IEnumerator MovimientoEnemy2()
    {
        yield return new WaitForSeconds(2);
        estado = (behaviour)Random.Range(0, 2);
        dir = Random.Range(0, 4);
        Moving();
        StartCoroutine(MovimientoEnemy2());
    }

    // Use this for initialization
    void Start()
    {
        enemyTwo.sEnemySpeed = 2.0f;
        enemyTwo.sEnemyHealth = 5;
        StartCoroutine(MovimientoEnemy2());
    }

    // Update is called once per frame
    void Update()
    {
        switch (estado)
        {

            case behaviour.moving:
                enemyTwo.sEnemySpeed = 2.0f;
                Moving();
                break;

            case behaviour.chasing:
                enemyTwo.sEnemySpeed = 3.0f;
                Moving();
                break;
        }
    }

    public void Moving()
    {
        switch (dir)
        {
            case 0:
                transform.position += transform.forward * enemyTwo.sEnemySpeed * Time.deltaTime;
                break;

            case 1:
                transform.position -= transform.forward * enemyTwo.sEnemySpeed * Time.deltaTime;
                break;

            case 2:
                transform.position += transform.right * enemyTwo.sEnemySpeed * Time.deltaTime;
                break;

            case 3:
                transform.position -= transform.right * enemyTwo.sEnemySpeed * Time.deltaTime;
                break;
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
            }
        }
    }
}
