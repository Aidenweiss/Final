using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    PlayerE player; //Llamada a las estructuras.
    FirstEnemyE fEnemy;
    SecondEnemyE sEnemy;
    CiudadanoE citizen;

    public GameObject Player; //Variables para instanciacion del jugador.
    GameObject playerClone;

    public GameObject enemyOne; //Variables para instanciacion del primer tipo de enemigo.
    GameObject enemyOneClone;

    [SerializeField]
    GameObject enemyTwo; //Variables para instanciacion del segundo tipo de enemigo.


    public GameObject ciudada; //Variables para instanciacion de los ciudadanos.
    GameObject ciudadaClone;

    int talk; //Variable que controla la conversacion heroe - ciudadano.
    
    public GameObject cargador;//Variables para instanciacion de los cargadores.
    GameObject cargadorClone;

    public int contCiu; //Variables que guardan la cantidad de ciudadanos y enemigos.
    public int contE1;
    public int contE2;

    public Text NC; //Variables que controlan el texto de las cantidades de enemigos, ciudadanos y vidas.
    public Text NE1;
    public Text NE2;
    public Text NL;

    public Text lose; //Variables que controlan la activacion de los mensajes de ganar o perder.
    public Text win;

  
    IEnumerator SpawnCharger() //Corrutina que controla la creacion de cargadores.
    {
        yield return new WaitForSeconds(20);
        spawnCharger(); //Llamada al metodo de creacion de cargadores.
        StartCoroutine(SpawnCharger());
    }

    // Use this for initialization
    void Start ()
    {
        heroSpawn(); //Llamada al contructor del heroe.

        for(int i = 0; i < 5; i++) //Ciclo que se encarga de crear los ciudadanos.
        {
           citizenSpawn();
        }

        for (int i = 0; i < 5; i++) //Ciclo que se encarga de crear el primer tipo de enemigos.
        {
            enemy1Spawn();
        }

        for (int i = 0; i < 5; i++) //Ciclo que se encarga de crear el segundo tipo de enemigos.
        {
            enemy2Spawn();   
        }

        StartCoroutine(SpawnCharger()); //Inicializacion de la corrutina que crea cargadores.
    }
	
	// Update is called once per frame
	void Update ()
    {
        NC.text = contCiu.ToString(); //Bloque de codigo que modifica los valores de los textos en el canvas.
        NE1.text = contE1.ToString();
        NE2.text = contE2.ToString();
        NL.text = FindObjectOfType<Player>().lifes.ToString();

        if (FindObjectOfType<Player>().Lose == true) //Condicional para activar el mensaje de Perdiste.
        {
            lose.enabled = true;
       
        }
        if (contE1 + contE2 == 0) //Condicional para activar el mensaje de Ganaste.
        {
            win.enabled = true;
        
        }
      
    }
    public void spawnCharger() //Constructor de los cargadores.
    {
        cargadorClone = Instantiate(cargador, transform.position, Quaternion.identity);
        Vector3 posCar = new Vector3();
        posCar.x = Random.Range(-20, 20);
        posCar.y = 1f;
        posCar.z = Random.Range(-20, 20);
        cargadorClone.transform.position = posCar;
        cargadorClone.tag = "Ammo";
        cargadorClone.AddComponent<Ammo>();
        
    }

    public void heroSpawn() //Constructor del jugador.
    {
        playerClone = Instantiate(Player, transform.position, Quaternion.identity);
        Camera.main.transform.SetParent(playerClone.transform, false);
        Camera.main.transform.localPosition = new Vector3(0f, 1f, 0.5f);
        Camera.main.gameObject.AddComponent<FPSAim>();

        Vector3 pos1 = new Vector3();
        pos1.x = Random.Range(-20, 20);
        pos1.y = 1f;
        pos1.z = Random.Range(-20, 20);
        playerClone.transform.position = pos1;

        playerClone.tag = "Player";
        playerClone.AddComponent<Player>();
        Rigidbody rgbdy1 = playerClone.AddComponent<Rigidbody>();
        rgbdy1.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    public void citizenSpawn() //Constructor de los ciudadanos.
    {
        ciudadaClone = Instantiate(ciudada, transform.position, Quaternion.identity);

        Vector3 pos2 = new Vector3();
        pos2.x = Random.Range(-20, 20);
        pos2.y = 1f;
        pos2.z = Random.Range(-20, 20);
        ciudadaClone.transform.position = pos2;

        ciudadaClone.tag = "Ciudadano";
        ciudadaClone.AddComponent<Citizen>();
        Rigidbody rgbdy2 = ciudadaClone.AddComponent<Rigidbody>();
        rgbdy2.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        contCiu++;//Variable para conteo de los ciudadanos.
    }

    public void enemy1Spawn() //Constructor para el primer tipo de enemigo.
    {
        enemyOneClone = Instantiate(enemyOne, transform.position, Quaternion.identity);

        Vector3 pos3 = new Vector3();
        pos3.x = Random.Range(-20, 20);
        pos3.y = 1f;
        pos3.z = Random.Range(-20, 20);
        enemyOneClone.transform.position = pos3;

        enemyOneClone.tag = "Enemy1";
        enemyOneClone.AddComponent<Enemy1>();
        Rigidbody rgbdy3 = enemyOneClone.AddComponent<Rigidbody>();
        rgbdy3.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        contE1++; //Variable para el conteo de este tipo de enemigo.
    }
    public void enemy2Spawn() //Constructor para el segundo tipo de enemigo.
    {
        GameObject enemyTwoClone;
        
        enemyTwoClone = Instantiate(enemyTwo, transform.position, Quaternion.identity);

        Vector3 pos4 = new Vector3();
        pos4.x = Random.Range(-20, 20);
        pos4.y = 1f;
        pos4.z = Random.Range(-20, 20);
        enemyTwoClone.transform.position = pos4;

        enemyTwoClone.tag = "Enemy2";
        enemyTwoClone.AddComponent<Enemy2>();
        Rigidbody rgbdy4 = enemyTwoClone.AddComponent<Rigidbody>();

        contE2++; //Variable para el conteo de este tipo de enemigo.
    }
}
