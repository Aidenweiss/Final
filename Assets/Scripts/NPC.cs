using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public int dir;
    public float speed;

    public behaviour estado;

    public IEnumerator MovimientoEnemy()
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

    public void Moving()
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
