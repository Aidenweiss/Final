using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerE
{
    public float playerSpeed;
    public int ammo;
    public int lifes;
}

public struct FirstEnemyE
{
    public float fEnemyHealth;
    public float fEnemySpeed;
}

public struct SecondEnemyE
{
    public float sEnemyHealth;
    public float sEnemySpeed;
}



 
public enum behaviour
{
    idle, moving, chasing
}



public struct CiudadanoE
{
    public float ciudSpeed;
    public int talk;
}



