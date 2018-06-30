using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Enemy1 : NPC
{

    FirstEnemyE enemyOne; //Llamada a la estructura del primer enemigo.
    public float uniDist = 5.0f; //Variable que guarda la distancia de persecucion.

    // Use this for initialization
    void Start ()
    {
        enemyOne.fEnemyHealth = 3; //Asignacion del total de vida del enemigo.
        StartCoroutine(MovimientoEnemy()); //Inicializacion de la corrutina que controla los estados y la direccion de mov.
    }

	// Update is called once per frame
	void Update ()
    {
      

        switch (estado) //Switch para los estados del enemigo, asignacion del valor de la variable speed
                        // y llamada al metodo de movimiento.
        {
            case behaviour.idle:
                speed = 0;
                Moving();
                break;

            case behaviour.moving:
                speed = 1.5f;
                Moving();
                break;

            case behaviour.chasing:
                speed = 2.0f;
                Moving();
                break;
        }

        buscar(); //Llamada al metodo buscar;

        if (target)
        {
            Vector3 myVector = target.transform.position - transform.position;

            float distanceToPlayer = myVector.magnitude;

            if (distanceToPlayer < uniDist) //Condicional para comenzar la persecucion.
            {
                estado = behaviour.chasing;
                transform.position += Vector3.Normalize(target.transform.position - transform.position) * speed * Time.deltaTime;
            }
        }

    }

    void OnCollisionEnter(Collision collision) //Metodo de colision para reducir la vida del enemigo.
    {
        if(collision.gameObject.tag == "Bullet")
        {
            enemyOne.fEnemyHealth--;
            
            if(enemyOne.fEnemyHealth == 0)
            {
                Destroy(gameObject);
                FindObjectOfType<Manager>().contE1--; //Acceso a la variable para el conteo de los enemigos.
            }
        }
    }

    public float distPlayer;
    public GameObject target;

    void buscar() //Metodo para la busqueda de un tipo de objeto.
    {
        GameObject[] AllGameObjects = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject go in AllGameObjects)
        {
            if (go.GetComponent<Citizen>())
            {
                float distancia = Vector3.Distance(go.transform.position, transform.position);

                if (distancia <= 15f && distPlayer > 8f)
                {
                    target = go;
                }
            }
            if (go.GetComponent<Player>())
            {
                float distancia = Vector3.Distance(go.transform.position, transform.position);
                distPlayer = distancia;
                if (distancia <= 15f)
                {
                    target = go;
                }
            }
        }
    }
}
