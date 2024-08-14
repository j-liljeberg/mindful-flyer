using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class EnergyDisplay : MonoBehaviour
{
    private TextMeshProUGUI textComponent;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();

        GameEvents.Instance.OnEnergyChanged += UpdateEnergyDisplay;
    }

    private void UpdateEnergyDisplay(int energy)
    {
        textComponent.text = energy.ToString();
    }
}
