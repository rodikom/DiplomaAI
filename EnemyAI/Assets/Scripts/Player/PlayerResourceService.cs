using Player;
using System;
using Interfaces;

namespace Player
{
    public class PlayerResourcesService : IStats
    {
        public Resource Health { get; }
        public Resource Mana { get; }
        public Resource Stamina { get; }

        public event Action<Resource> OnStatsChanged;

        private readonly IPlayerStatsService _playerStats;

        public PlayerResourcesService(IPlayerStatsService playerStats)
        {
            _playerStats = playerStats;

            Health = new Resource(CalcHealthMax(), CalcHealthMax());
            Mana = new Resource(CalcManaMax(), CalcManaMax());
            Stamina = new Resource(CalcStaminaMax(), CalcStaminaMax());

            Health.OnValueChanged += _ => OnStatsChanged?.Invoke(Health);
            Mana.OnValueChanged += _ => OnStatsChanged?.Invoke(Mana);
            Stamina.OnValueChanged += _ => OnStatsChanged?.Invoke(Stamina);

            _playerStats.OnStatsChanged += Recalculate;
        }

        private void Recalculate()
        {
            Health.SetMax(CalcHealthMax());
            Mana.SetMax(CalcManaMax());
            Stamina.SetMax(CalcStaminaMax());
        }

        private float CalcHealthMax()
        {
            return 100 + _playerStats.GetStat(StatType.Vitality) * 20;
        }

        private float CalcManaMax()
        {
            return 50 + _playerStats.GetStat(StatType.Intelligence) * 15;
        }

        private float CalcStaminaMax()
        {
            return 75 + _playerStats.GetStat(StatType.Endurance) * 10;
        }
    }
}