using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSAim : MonoBehaviour {

    float mouseX; //Variable que controla el valor de la rotacion de la camara en X.
    float mouseY; //Variable que controla el valor de la rotacion de la camara en Y.
    public bool invertedMouse; //Booleano que controla la inverison de los controles de la camara en Y.
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        giro(); //Llamada a la clase giro.
        if (invertedMouse) //Condicional del booleano para invertir los controles de la camara en Y.
        {
            mouseY += Input.GetAxis("Mouse Y");
            
        }
        else
        {
            mouseY -= Input.GetAxis("Mouse Y");
        }
        
    }

    public void giro() //Clase que controla el giro de la camara en X.
    {
        mouseX += Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }

    
}
