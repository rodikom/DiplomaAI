using Interfaces;
using Services;
using UnityEngine;
using Player;

public class AppLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        InitializeServices();
    }

    public void Start()
    {
        var gameLoop = ServiceLocator.Get<IGameLoopService>();
        gameLoop.GoMenu();
    }

   private void InitializeServices()
{
    ServiceLocator.Clear();
    
    var stateMachine = new GameStateMachine();
    var gameLoop = new GameLoopService(stateMachine);
    var experience = new ExperienceService();

    ServiceLocator.Register<GameStateMachine>(stateMachine);
    ServiceLocator.Register<IGameLoopService>(gameLoop);
    ServiceLocator.Register<IExperienceService>(experience);

    var playerStats = new PlayerStatsService(experience);
    ServiceLocator.Register<IPlayerStatsService>(playerStats);

    var playerResources = new PlayerResourcesService(playerStats);
    ServiceLocator.Register<IStats>(playerResources);
}
}
