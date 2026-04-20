using Interfaces;
public sealed class GameStateMachine
{
    private IGameState _currentState;

    public void ChangeState(
        IGameState newState,
        ITransitionCommand transitionCommand = null)
    {
        _currentState?.Exit();

        transitionCommand?.Execute();

        _currentState = newState;

        _currentState.Enter();
    }
}