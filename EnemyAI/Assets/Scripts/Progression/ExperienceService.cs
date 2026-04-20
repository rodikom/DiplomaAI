using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Interfaces;

namespace Services
{
    public class ExperienceService : IExperienceService
    {
        public Resource Experience { get; }
        public float LostExperience { get; private set; }

        public event Action<float> OnExperienceChanged;

        public ExperienceService(float maxExp = 999999)
        {
            Experience = new Resource(maxExp, 0);
            Experience.OnValueChanged += exp => OnExperienceChanged?.Invoke(exp);
        }


        public void AddExperience(float amount)
        {
            if (amount <= 0) return;
            Experience.Add(amount);
        }


        public bool TrySpendExperience(float amount)
        {
            if (amount <= 0) return true;

            if (Experience.Current < amount)
                return false;

            Experience.Consume(amount);
            return true;
        }


        public void OnPlayerDeath()
        {
            LostExperience = Experience.Current;
            Experience.Set(0);
        }

        public void RestoreLostExperience(float ratio)
        {
            ratio = Mathf.Clamp01(ratio);

            float restored = LostExperience * ratio;
            LostExperience -= restored;

            Experience.Add(restored);
        }
    }
}
