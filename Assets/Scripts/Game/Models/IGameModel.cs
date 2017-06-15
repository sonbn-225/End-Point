using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameModel 
{
    int gameSpeed { get; set; }
    Transform towerTransform { get; set; }
}
