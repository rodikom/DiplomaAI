using System;

namespace Interfaces
{
    public interface IStats
    {
        Resource Health { get; }
        Resource Mana { get; }
        Resource Stamina { get; }

        event Action<Resource> OnStatsChanged;
    }
}