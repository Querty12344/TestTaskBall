using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class UIMediator : MonoBehaviour
{
    private GameLoop _gameLoop;
    private WindowsOpener _windows;

    public void Construct(GameLoop gameLoop , WindowsOpener windows)
    {
        _windows = windows;
        _gameLoop = gameLoop;
    }
    
    public void StartGame()
    {
        _gameLoop.StartLoop();
    }

    public void Replay()
    {
        _gameLoop.RestartLoop();
    }

    public void PauseGame()
    {
        _windows.OpenPause();
        _gameLoop.Pause(true);
    }

    public void Continue()
    { 
        _gameLoop.Pause(false);

    }
}
