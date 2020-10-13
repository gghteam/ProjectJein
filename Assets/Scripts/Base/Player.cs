using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player
{
    public long calcium = 0;
    public float jeinHeight = 154.4f;
    public Doll[] dolls;
}

[Serializable]
public class Doll 
{
    public long level = 1;
    public float purchaseCost = 10f;
    public float upgradeCost = 0.1f;
    public long calciumPerSecond = 10;
}