using Interfaces;
using System;

namespace Player
{ 
    public class PlayerStatsService : IPlayerStatsService
    {
        private readonly PlayerStats _stats;
        private readonly IExperienceService _experienceService;
        public int Level { get; private set; }
        public event Action OnStatsChanged;
        public PlayerStatsService(IExperienceService experienceService)
        {
            _experienceService = experienceService;
            _stats = new PlayerStats();
            Level = 1;
        }
        public int GetStat(StatType type)
        {
            return _stats.Get(type);
        }
        public bool CanUpgrade(StatType type)
        {
            return _experienceService.Experience.Current >= GetUpgradeCost();
        }
        public bool Upgrade(StatType type)
        {
            int cost = GetUpgradeCost();

            if (!_experienceService.TrySpendExperience(cost))
                return false;

            _stats.Increase(type, 1);
            Level++;

            OnStatsChanged?.Invoke();
            return true;
        }
        private int GetUpgradeCost()
        {
            return 100 + (Level * 50);
        }
    }
}