using UnityEngine;
using UnityEngine.SceneManagement;
using Interfaces;

public sealed class GameState : IGameState
{
    public void Enter()
    {
        SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MainMenuScene");
    }

    public void Exit()
    {
        SceneManager.UnloadSceneAsync("GameScene");
    }
}