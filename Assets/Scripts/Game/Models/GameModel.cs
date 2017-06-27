using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : IGameModel
{
    public int gameSpeed { get; set; }
    public Transform towerTransform { get; set; }
    public float attackInterval { get; set; }
}
