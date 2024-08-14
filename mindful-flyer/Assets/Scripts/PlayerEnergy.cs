using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] int energy;

    public float Energy { get { return energy; } }

    private bool firstUpdate = true;


    void Update()
    {
        if (firstUpdate)
        {
            UpdateEnergy();
            firstUpdate = false;
        }
    }

    public void Increase(int energy)
    {
        this.energy += energy;
        UpdateEnergy();
    }

    public void Decrease(int energy)
    {
        this.energy -= energy;
        UpdateEnergy();
    }

    public bool TryToUse(int energy)
    {
        if (this.energy >= energy)
        {
            this.energy -= energy;
            UpdateEnergy();
            return true;
        }
        return false;
    }

    private void UpdateEnergy()
    {
        GameEvents.Instance.EnergyChanged(energy);
    }
}
