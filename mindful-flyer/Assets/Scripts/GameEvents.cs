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

    public event Action<int> OnEnergyChanged;
    public void EnergyChanged(int health)
    {
        OnEnergyChanged?.Invoke(health);
    }
}
