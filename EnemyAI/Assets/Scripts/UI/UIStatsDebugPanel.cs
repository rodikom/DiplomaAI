using UnityEngine;
using UnityEngine.UI;
using Interfaces;

namespace UI
{
    public class UIStatsDebugPanel : MonoBehaviour
    {
        private IStats _stats;
        private IExperienceService _exp;

        private void Start()
        {
            _stats = ServiceLocator.Get<IStats>();
            _exp = ServiceLocator.Get<IExperienceService>();
        }

        // HEALTH
        public void AddHealth() => _stats.Health.Add(25);
        public void DamageHealth() => _stats.Health.Consume(25);

        // MANA
        public void AddMana() => _stats.Mana.Add(20);
        public void SpendMana() => _stats.Mana.Consume(20);

        // STAMINA
        public void AddStamina() => _stats.Stamina.Add(30);
        public void SpendStamina() => _stats.Stamina.Consume(30);

        // EXP
        public void AddExp() => _exp.AddExperience(100);
        public void RemoveExp() => _exp.TrySpendExperience(100);
    }
}