using UnityEngine;
public sealed class MainMenuToGameCommand : ITransitionCommand
{
    public void Execute()
    {
        Debug.Log("Transition: MainMenu → Game");
    }
}