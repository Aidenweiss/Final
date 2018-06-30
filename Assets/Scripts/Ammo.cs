using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    //Metodo de colision que desactiva los cargadores con los que choca el jugador.
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
