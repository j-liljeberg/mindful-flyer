using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Register to event in Start()

    public event Action<int> OnEnergyChanged;
    public void EnergyChanged(int health)
    {
        OnEnergyChanged?.Invoke(health);
    }

    public event Action OnRestart;
    public void Restart()
    {
        OnRestart?.Invoke();
    }

    public event Action OnLevelHalfway;
    public void LevelHalfway()
    {
        OnLevelHalfway?.Invoke();
    }

    public event Action OnLevelEnd;
    public void LevelEnd()
    {
        OnLevelEnd?.Invoke();
    }
}
