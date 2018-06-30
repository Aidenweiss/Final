using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int lifes;
    public bool Lose = false;
   
  

	// Use this for initialization
	void Start ()
    {
        lifes = 3;
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
            FindObjectOfType<Bullet>().ammo = 10;
            Debug.Log("Recargaste las balas");
        }

        if (colision.gameObject.tag == "Enemy1" || colision.gameObject.tag == "Enemy2")
        {
            lifes--;

            Vector3 pos1 = new Vector3();
            pos1.x = Random.Range(-20, 20);
            pos1.y = 1f;
            pos1.z = Random.Range(-20, 20);
            gameObject.transform.position = pos1;

            if(lifes == 0)
            {
                Lose = true;
            }
        }
    }
}
