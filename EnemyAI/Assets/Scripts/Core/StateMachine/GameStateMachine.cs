using Interfaces;
public sealed class GameStateMachine
{
    public IGameState CurrentState { get; private set; }

    public void ChangeState(
        IGameState newState,
        ITransitionCommand transitionCommand = null)
    {
        CurrentState?.Exit();
        transitionCommand?.Execute();
        CurrentState = newState;
        CurrentState.Enter();
    }
}