using Interfaces;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using Player;

public class AppLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        InitializeServices();
        LoadMainMenu();
    }

   private void InitializeServices()
{
    ServiceLocator.Clear();

    var gameLoop = new GameLoopService();
    var experience = new ExperienceService();

    ServiceLocator.Register<IGameLoopService>(gameLoop);
    ServiceLocator.Register<IExperienceService>(experience);

    var playerStats = new PlayerStatsService(experience);
    ServiceLocator.Register<IPlayerStatsService>(playerStats);

    var playerResources = new PlayerResourcesService(playerStats);
    ServiceLocator.Register<IStats>(playerResources);
}

    private void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenuScene", LoadSceneMode.Additive);
    }
}
