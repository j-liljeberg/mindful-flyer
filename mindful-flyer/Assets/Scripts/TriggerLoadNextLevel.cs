using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLoadNextLevel : MonoBehaviour
{
    private Transform player;

    private bool isActivated = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player != null && !isActivated)
        {
            if (player.position.z >= transform.position.z)
            {
                isActivated = true;
                GameEvents.Instance.LoadNextLevel();
            }
        }
    }
}
