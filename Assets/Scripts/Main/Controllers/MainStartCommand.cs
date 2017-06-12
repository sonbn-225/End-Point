using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStartCommand : Command {
    [Inject]
    public IGameModel gameModel { get; set; }
    
    public override void Execute()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        gameModel.gameSpeed = 1;
    }
}
