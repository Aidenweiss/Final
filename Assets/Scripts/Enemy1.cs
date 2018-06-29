using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

    FirstEnemyE enemyOne;
    

    int dir;

    behaviour estado;

    int idle = 0;
    int moving;
    int chasing;

    IEnumerator MovimientoEnemy1()
    {
        yield return new WaitForSeconds(2);
        estado = (behaviour)Random.Range(0, 2);
        dir = Random.Range(0, 4);
        Moving();
        StartCoroutine(MovimientoEnemy1());
    }

    // Use this for initialization
    void Start ()
    {
        enemyOne.fEnemySpeed = 1.5f;
        enemyOne.fEnemyHealth = 3;
        StartCoroutine(MovimientoEnemy1());
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (estado)
        {

            case behaviour.moving:
                enemyOne.fEnemySpeed = 1.5f;
                Moving();
                break;

            case behaviour.chasing:
                enemyOne.fEnemySpeed = 2.0f;
                Moving();
                break;
        }
    }

    public void Moving()
    {
        switch (dir)
        {
            case 0:
                transform.position += transform.forward * enemyOne.fEnemySpeed * Time.deltaTime;
                break;

            case 1:
                transform.position -= transform.forward * enemyOne.fEnemySpeed * Time.deltaTime;
                break;

            case 2:
                transform.position += transform.right * enemyOne.fEnemySpeed * Time.deltaTime;
                break;

            case 3:
                transform.position -= transform.right * enemyOne.fEnemySpeed * Time.deltaTime;
                break;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            enemyOne.fEnemyHealth--;
            
            if(enemyOne.fEnemyHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
