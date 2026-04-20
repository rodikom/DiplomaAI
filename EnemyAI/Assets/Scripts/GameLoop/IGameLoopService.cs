namespace Interfaces
{
    public interface IGameLoopService
    {
        void StartGame();
        void Pause();
        void Resume();
        bool IsPaused { get; }
    }
}