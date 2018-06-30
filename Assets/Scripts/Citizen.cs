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
        speed = 1.7f;
        citizen.talk = Random.Range(0, 5);
        StartCoroutine(MovimientoEnemy());
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        Moving();

        buscar();//llamando el metodo de busqueda
                 // y le digo que al que el target se alege de la pocicion del zombie mas cercano 
        if (target)
        {
            Vector3 myVector = target.transform.position - transform.position;

            float distanceToPlayer = myVector.magnitude;

            if (distanceToPlayer < uniDist)
            {
                transform.position += Vector3.Normalize(target.transform.position + transform.position) * citizen.ciudSpeed * Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
    if (collision.gameObject.tag == "Enemy1")
        {

            FindObjectOfType<Manager>().enemy2Spawn();
            gameObject.SetActive(false);
            FindObjectOfType<Manager>().contCiu--;
        }    
    }
    

    void buscar()
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
