using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GetPowerUp : MonoBehaviour
{
    [SerializeField] InputActionReference activateAction;
    [SerializeField] Transform aimTransform;
    [SerializeField] float maxDistance = 12f;

    private bool isActive = false;
    private int powerUpLayerMask;

    void Start()
    {
        powerUpLayerMask = LayerMask.GetMask("Power-ups");
        if (activateAction)
        {
            activateAction.action.performed += (_) => isActive = true;
            activateAction.action.canceled += (_) => isActive = false;
        }
    }

    void Update()
    {
        if (isActive)
        {
            RaycastHit hitPoint;
            if (Physics.Raycast(aimTransform.position, aimTransform.forward, maxDistance, powerUpLayerMask))
            {
                Debug.Log("Hit power-up");
            }
        }
    }
}
