using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IExperienceService
    {
        Resource Experience { get; }

        float LostExperience { get; }

        void AddExperience(float amount);
        bool TrySpendExperience(float amount);

        void OnPlayerDeath();
        void RestoreLostExperience(float ratio); 

        event Action<float> OnExperienceChanged;
    }
}
