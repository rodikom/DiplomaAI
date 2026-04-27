using Interfaces;

namespace Services
{
    public sealed class GameLoopService : IGameLoopService
    {
        private readonly GameStateMachine _stateMachine;

        private readonly IGameState _mainMenuState;
        private readonly IGameState _gameState;
        private readonly IGameState _pauseState;

        public bool IsPaused { get; private set; }
        public GameLoopService(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;

            _mainMenuState = new MainMenuState();
            _gameState = new GameState();
            _pauseState = new PauseState();
        }

        public void StartGame()
        {
            IsPaused = false;

            _stateMachine.ChangeState(
                _gameState,
                new MainMenuToGameCommand()
            );
        }

        public void Pause()
        {
            if (IsPaused)
                return;

            IsPaused = true;

            _stateMachine.ChangeState(
                _pauseState,
                new GameToPauseCommand()
            );
        }

        public void Resume()
        {
            if (!IsPaused)
                return;

            IsPaused = false;

            _stateMachine.ChangeState(
                _gameState
            );
        }

        public void GoMenu()
        {
            _stateMachine.ChangeState(
                _mainMenuState
            );
        }
    }
}