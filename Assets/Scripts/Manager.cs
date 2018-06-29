using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    PlayerE player;
    FirstEnemyE fEnemy;
    SecondEnemyE sEnemy;
    CiudadanoE citizen;

    public GameObject Player;
    GameObject playerClone;

    public GameObject enemyOne;
    GameObject enemyOneClone;

    public GameObject enemyTwo;
    GameObject enemyTwoClone;

    public GameObject ciudada;
    GameObject ciudadaClone;

    int talk;
    
    public GameObject cargador;
    GameObject cargadorClone;

    IEnumerator SpawnCharger()
    {
        yield return new WaitForSeconds(10);
        spawnCharger();
        StartCoroutine(SpawnCharger());
    }

    // Use this for initialization
    void Start ()
    {
        heroSpawn();

        for(int i = 0; i < 5; i++)
        {
           citizenSpawn();
        }

        for (int i = 0; i < 2; i++)
        {
            enemy1Spawn();
        }

        for (int i = 0; i < 5; i++)
        {
            enemy2Spawn();   
        }

        StartCoroutine(SpawnCharger());
    }
	
	// Update is called once per frame
	void Update ()
    {
       
     
    }
    public void spawnCharger()
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

    public void heroSpawn()
    {
        playerClone = Instantiate(Player, transform.position, Quaternion.identity);
        Camera.main.transform.SetParent(playerClone.transform, false);
        Camera.main.transform.localPosition = new Vector3(0f, 1f, 0.5f);
        Camera.main.gameObject.AddComponent<FPSAim>();

        Vector3 pos1 = new Vector3();
        pos1.x = Random.Range(-10, 10);
        pos1.y = 1f;
        pos1.z = Random.Range(-10, 10);
        playerClone.transform.position = pos1;


        playerClone.tag = "Player";
        playerClone.AddComponent<Player>();
        Rigidbody rgbdy1 = playerClone.AddComponent<Rigidbody>();
        rgbdy1.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    public void citizenSpawn()
    {
        ciudadaClone = Instantiate(ciudada, transform.position, Quaternion.identity);

        Vector3 pos2 = new Vector3();
        pos2.x = Random.Range(-10, 10);
        pos2.y = 1f;
        pos2.z = Random.Range(-10, 10);
        ciudadaClone.transform.position = pos2;

        ciudadaClone.tag = "Ciudadano";
        ciudadaClone.AddComponent<Citizen>();
        Rigidbody rgbdy2 = ciudadaClone.AddComponent<Rigidbody>();
        rgbdy2.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    public void enemy1Spawn()
    {
        enemyOneClone = Instantiate(enemyOne, transform.position, Quaternion.identity);

        Vector3 pos3 = new Vector3();
        pos3.x = Random.Range(-10, 10);
        pos3.y = 1f;
        pos3.z = Random.Range(-10, 10);
        enemyOneClone.transform.position = pos3;

        enemyOneClone.tag = "Enemy1";
        enemyOneClone.AddComponent<Enemy1>();
        Rigidbody rgbdy3 = enemyOneClone.AddComponent<Rigidbody>();
        rgbdy3.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    public void enemy2Spawn()
    {
        enemyTwoClone = Instantiate(enemyTwo, transform.position, Quaternion.identity);

        Vector3 pos4 = new Vector3();
        pos4.x = Random.Range(-10, 10);
        pos4.y = 1f;
        pos4.z = Random.Range(-10, 10);
        enemyTwoClone.transform.position = pos4;

        enemyTwoClone.tag = "Enemy2";
        enemyTwoClone.AddComponent<Enemy2>();
        Rigidbody rgbdy4 = enemyTwoClone.AddComponent<Rigidbody>();
    }
}
