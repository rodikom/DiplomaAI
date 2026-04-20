using UnityEngine;
using UnityEngine.SceneManagement;
using Interfaces;

public sealed class MainMenuState : IGameState
{
    public void Enter()
    {
        SceneManager.LoadSceneAsync("MainMenuScene", LoadSceneMode.Additive);
    }

    public void Exit()
    {
        SceneManager.UnloadSceneAsync("MainMenuScene");
    }
}