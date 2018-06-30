using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public int ammo; //Variable que guarda la cantidad de municion.

    public GameObject bullet; //Variables para instanciacion de las balas.
    GameObject bulletClone;

    private float cadencia; //Variable que guarda el tiempo de cadencia entre disparos.
    private float Force; //Variable que guarda la fuerza aplicada a las balas.
  
	// Use this for initialization
	void Start ()
    {
        Force = 30f;
        ammo = 10;
	}

 

    // Update is called once per frame
    public void Update()
    {
        if (cadencia <= 0.5f) //Condicional para evitar spam de disparos.
        {
            cadencia += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0)) //Condicional para disparar.
        {
            if (ammo > 0)
            {
                if (cadencia >= 0.5f)
                {
                    Shoot(); //Llamada al metodo de disparar.
                    ammo--;
                    cadencia = 0;
                }
            }
            else
            {
                Debug.Log("No quedan balas");
                
            }
        }

    }
    public void Shoot() //Metodo encargado de instanciar, aplicar fuerza a las balas y finalmente destruirlas.
    {
        
        bulletClone = Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.tag = "Bullet";
        bulletClone.AddComponent<Rigidbody>().AddForce(bulletClone.transform.forward * Force, ForceMode.Impulse);
        Destroy(bulletClone.gameObject, 1.5f);
        
    }
   
}
