using UnityEngine;
public sealed class GameToPauseCommand : ITransitionCommand
{
    public void Execute()
    {
        Debug.Log("Transition: Game → Pause");
    }
}