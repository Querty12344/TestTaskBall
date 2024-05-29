using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private LevelFactory _factory;
    private LevelBound _bound;
    private LevelGenerator _levelGenerator;
    private WindowsOpener _windowsOpener;


    public GameLoop(LevelFactory factory , LevelBound bound , LevelGenerator levelGenerator , WindowsOpener windowsOpener)
    {
        _windowsOpener = windowsOpener;
        _levelGenerator = levelGenerator;
        _bound = bound;
        _factory = factory;
        _bound.OnPlayerHit += Lose;
    }
    public void StartLoop()
    {
        _levelGenerator.Clear();
        _factory.ClearLevel();
        _factory.CreatePlayer();
         _levelGenerator.StartGenerating();
         _windowsOpener.ShowHUD();
    }

    public void RestartLoop()
    {
        _levelGenerator.Clear();
        _factory.ClearLevel();
        _windowsOpener.OpenStart();
    }

    public void Pause(bool pause)
    {
        _factory.PauseAll(pause);
        _levelGenerator.SetPause(pause);
    }
    public void Lose()
    {
        _levelGenerator.Clear();
        _windowsOpener.OpenLose(_factory.GetPlayerPoints());
        _factory.ClearLevel();
    }
}
