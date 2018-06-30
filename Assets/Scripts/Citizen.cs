using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Citizen : NPC
{
    
    public CiudadanoE citizen;
    public float distPlayer;
    public GameObject target;
    public float uniDist = 5.0f;

    // Use this for initialization
    void Start ()
    {
        speed = 1.7f; //Asignacion del valor a la variable velocidad.
        citizen.talk = Random.Range(0, 5); //Randomizador que controla la info que devela cada ciudadano.
        StartCoroutine(MovimientoEnemy()); //Inicializacion de la corrutina de movimiento.
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        Moving();//Llamada al metodo de movimiento.

        buscar();//Llamada al metodo de busqueda
                 
        if (target)
        {
            Vector3 myVector = target.transform.position - transform.position;

            float distanceToPlayer = myVector.magnitude;

            if (distanceToPlayer < uniDist) //Condicional para huir de los persecutores.
            {
                transform.position += Vector3.Normalize(target.transform.position + transform.position) * citizen.ciudSpeed * Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter(Collision collision) //Metodo de colision para corrupcion de los ciudadanos.
    {
    if (collision.gameObject.tag == "Enemy1")
        {

            FindObjectOfType<Manager>().enemy2Spawn(); //El bloque de codigo desactiva al ciudadano y spawnea un enemigo.
            gameObject.SetActive(false);
            FindObjectOfType<Manager>().contCiu--;
        }    
    }
    

    void buscar() //Metodo para buscar a los enemigos.
    {
        GameObject[] AllGameObjects = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject go in AllGameObjects)
        {
            if (go.GetComponent<Enemy1>())
            {
                float distancia = Vector3.Distance(go.transform.position, transform.position);

                if (distancia <= 15f)
                {
                    target = go;
                }
            }
            else if (go.GetComponent<Enemy2>())
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
