using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace endpoint.game
{
    public interface IGameConfig
    {
        int baseEnemyScore { get; set; }
    }
}
