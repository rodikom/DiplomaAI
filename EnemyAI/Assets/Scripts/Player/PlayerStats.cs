using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class PlayerStats
    {
        private readonly Dictionary<StatType, int> _stats;

        public PlayerStats()
        {
            _stats = new Dictionary<StatType, int>
        {
            { StatType.Strength, 10 },
            { StatType.Dexterity, 10 },
            { StatType.Intelligence, 10 },
            { StatType.Vitality, 10 },
            { StatType.Endurance, 10 }
        };
        }

        public int Get(StatType type) => _stats[type];

        public void Increase(StatType type, int value)
        {
            _stats[type] += value;
        }

        public IReadOnlyDictionary<StatType, int> All => _stats;
    }
}
