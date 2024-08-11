using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] float energy;

    public float Energy { get { return energy; } }

    private float displayedEnergy; // TODO: Remove when HUD is implemented

    public void Increase(float energy)
    {
        this.energy += energy;
    }

    public void Decrease(float energy)
    {
        this.energy -= energy;
    }

    public bool TryToUse(float energy)
    {
        if (this.energy >= energy)
        {
            this.energy -= energy;
            return true;
        }
        return false;
    }

    void Update()
    {
        if(displayedEnergy != energy)
        {
            displayedEnergy = energy;
            Debug.Log($"Energy: {displayedEnergy}");
        }
    }
}
