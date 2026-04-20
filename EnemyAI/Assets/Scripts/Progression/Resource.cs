using UnityEngine;
using Interfaces;
using System;

public class Resource
{
    public float Current { get; private set; }
    public float Max { get; private set; }

    public event Action<float> OnValueChanged;

    public Resource(float max, float initial = 0)
    {
        Max = max;
        Current = Mathf.Clamp(initial, 0, Max);
    }

    public void SetMax(float newMax)
    {
        Max = Mathf.Max(0, newMax);
        Current = Mathf.Min(Current, Max);
        OnValueChanged?.Invoke(Current);
    }

    public void Add(float value)
    {
        Current = Mathf.Min(Max, Current + value);
        OnValueChanged?.Invoke(Current);
    }

    public void Consume(float value)
    {
        Current = Mathf.Max(0, Current - value);
        OnValueChanged?.Invoke(Current);
    }

    public void Set(float value)
    {
        Current = Mathf.Clamp(value, 0, Max);
        OnValueChanged?.Invoke(Current);
    }
}
