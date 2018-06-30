using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerE //Estructura para el jugador.
{
    public float playerSpeed;
    public int ammo;
    public int lifes;
}

public struct FirstEnemyE //Estructura para el primer tipo de enemigo.
{
    public float fEnemyHealth;
    public float fEnemySpeed;
}

public struct SecondEnemyE //Estructura para el segundo tipo de enemigo.
{
    public float sEnemyHealth;
    public float sEnemySpeed;
}



 
public enum behaviour //Enumerador para los estados de los npc.
{
    idle, moving, chasing
}



public struct CiudadanoE //Estructura para los ciudadanos.
{
    public float ciudSpeed;
    public int talk;
}



