using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Net.Share;
using Net.Component;
using System;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

public class MyClientSceneManager : Net.Component.SceneManager
{
    public override void OnOperationOther(Operation opt)
    {
        switch (opt.cmd)
        {
            case GameCommand.startGame:
                SceneManager.LoadScene("MainGame");
                    break;
        }
    }
}
