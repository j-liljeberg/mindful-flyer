using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class GetPowerUp : MonoBehaviour
{
    [SerializeField] InputActionReference activateAction;
    [SerializeField] Transform aimTransform;
    [SerializeField] float maxDistance = 12f;

    private int powerUpLayerMask;
    private bool isActive = false;
    private int activePowerUpInstanceID = 0;
    private PowerUp activePowerUp = null;
    private float elapsedPowerUpTime = 0f;

    void Start()
    {
        powerUpLayerMask = LayerMask.GetMask("Power-ups");

        if (activateAction)
        {
            activateAction.action.started += (_) => isActive = true;

            activateAction.action.canceled += (_) => {
                isActive = false;
                ResetValues();
            };
        }
    }

    void Update()
    {
        if (isActive)
        {
            RaycastHit hitPoint;
            if (Physics.Raycast(aimTransform.position, aimTransform.forward, out hitPoint, maxDistance, powerUpLayerMask, QueryTriggerInteraction.UseGlobal))
            {

                if (activePowerUpInstanceID != hitPoint.collider.gameObject.GetInstanceID())
                {
                    elapsedPowerUpTime = 0f;
                    activePowerUpInstanceID = hitPoint.collider.gameObject.GetInstanceID();
                    activePowerUp = hitPoint.collider.gameObject.GetComponent<PowerUp>();
                }

                if (activePowerUp)
                {
                    elapsedPowerUpTime += Time.deltaTime;

                    if (elapsedPowerUpTime >= activePowerUp.ActivationTime)
                    {
                        elapsedPowerUpTime = 0f;
                        if (activePowerUp)
                        {
                            activePowerUp.GetPowerUp();
                        }
                    }
                }
            }
            else
            {
                ResetValues();
            }
        }
    }

    private void ResetValues()
    {
        elapsedPowerUpTime = 0f;
        activePowerUp = null;
        activePowerUpInstanceID = 0;
    }
}
