    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngine.SceneManagement;
    using Interfaces;

    public sealed class PauseInputHandler  : MonoBehaviour
    {
        private IGameLoopService _gameLoop;
        private GameStateMachine _gameStateMachine;

        private void Start()
        {
            _gameLoop = ServiceLocator.Get<IGameLoopService>();
            _gameStateMachine = ServiceLocator.Get<GameStateMachine>();
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            if (_gameStateMachine.CurrentState is MainMenuState && !_gameLoop.IsPaused)
                return;

            if (_gameLoop.IsPaused)
                _gameLoop.Resume();
            else
                _gameLoop.Pause();
        }
    }
