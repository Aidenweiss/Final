using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : Manager
{
    
    public CiudadanoE citizen;
    

	// Use this for initialization
	void Start ()
    {
        citizen.ciudSpeed = 1.7f;
        citizen.talk = Random.Range(0, 5);	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision collision)
    {
    if (collision.gameObject.tag == "Enemy1")
        {
            enemy2Spawn();
            Destroy(gameObject);
        }    
    }
}
