namespace Interfaces
{
    public interface IGameLoopService
    {
        void StartGame();
        void Pause();
        void Resume();
        void GoMenu();
        bool IsPaused { get; }
    }
}