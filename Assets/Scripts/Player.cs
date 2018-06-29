using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Manager {

    PlayerE playerInfo;
    public bool empty = true;
  

	// Use this for initialization
	void Start ()
    {
        playerInfo.lifes = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
      

	}

    void OnCollisionEnter(Collision colision)
    {
        if (colision.gameObject.tag == "Ciudadano")
        {
            
            switch (colision.gameObject.GetComponent<Citizen>().citizen.talk)
            {
                case 0:
                    Debug.Log("Los enemigos azules mueren con 3 disparos");
                    break;
                case 1:
                    Debug.Log("Los enemigos rojos mueren con 5 disparos");
                    break;
                case 2:
                    Debug.Log("Solo los enemigos azules pueden corromper a los ciudadanos");
                    break;
                case 3:
                    Debug.Log("Si un ciudadano se corrompe, se transformara en un enemigo rojo");
                    break;
                case 4:
                    Debug.Log("Si se te acaban las balas, coge los cargadores amarillos que aparecen en el mapa");
                    break;

            }
        }

        if (colision.gameObject.tag == "Ammo")
        {
            empty = false;
        }

        if (colision.gameObject.tag == "Enemy1" || colision.gameObject.tag == "Enemy2")
        {
            playerInfo.lifes--;
        }
    }
}
