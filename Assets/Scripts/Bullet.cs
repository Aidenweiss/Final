using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public int ammo;
    public GameObject bullet;
    GameObject bulletClone;

    private float cadencia;
    private float Force;
  
	// Use this for initialization
	void Start ()
    {
        Force = 30f;
        ammo = 10;
	}

 

    // Update is called once per frame
    public void Update()
    {
        if (cadencia <= 0.5f)
        {
            cadencia += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (ammo > 0)
            {
                if (cadencia >= 0.5f)
                {
                    Shoot();
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
    public void Shoot()
    {
        
        bulletClone = Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.tag = "Bullet";
        bulletClone.AddComponent<Rigidbody>().AddForce(bulletClone.transform.forward * Force, ForceMode.Impulse);
        Destroy(bulletClone.gameObject, 1.5f);
        
    }
   
}
