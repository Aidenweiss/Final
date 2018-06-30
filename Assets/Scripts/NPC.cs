using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public int dir; //Variable que guarda la direccion del mov de los npc.
    public float speed; //variable que guarda la velocidad del mov de los npc.

    public behaviour estado; //variable que guarda los estados de los npc.

    public IEnumerator MovimientoEnemy() //Corrutina que controla el estado y la dierccion del movimiento de los npc.
    {
        yield return new WaitForSeconds(2);
        estado = (behaviour)Random.Range(0, 2);
        dir = Random.Range(0, 4);
        Moving();
        StartCoroutine(MovimientoEnemy());
    }
    // Use this for initialization
    void Start ()
    {
        
      
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Moving() //Metodo para el movimiento de los npc.
    {
        switch (dir)
        {
            case 0:
                transform.position += transform.forward * speed * Time.deltaTime;
                break;

            case 1:
                transform.position -= transform.forward * speed * Time.deltaTime;
                break;

            case 2:
                transform.position += transform.right * speed * Time.deltaTime;
                break;

            case 3:
                transform.position -= transform.right * speed * Time.deltaTime;
                break;
        }
    }

  
}
