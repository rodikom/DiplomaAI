using UnityEngine;
using UnityEngine.SceneManagement;
using Interfaces;
public sealed class PauseState : IGameState
{
    public void Enter()
    {
        SceneManager.LoadSceneAsync("PauseScene", LoadSceneMode.Additive);
    }

    public void Exit()
    {
        SceneManager.UnloadSceneAsync("PauseScene");
    }
}