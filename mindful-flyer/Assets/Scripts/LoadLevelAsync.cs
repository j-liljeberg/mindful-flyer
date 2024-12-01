using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    private const float LevelLength = 100f;
    private const int maxNumLoadedLevels = 2;

    [SerializeField] List<string> levels;

    private Transform player;
    private LinkedList<Scene> loadedLevels = new();
    private int currentLevelIndex = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        StartCoroutine(LoadLevelAsync(levels[currentLevelIndex], (scene) =>
        {
            loadedLevels.AddLast(scene);
        }));

        GameEvents.Instance.OnLoadNextLevel += LoadLevelNext;
    }

    private void LoadLevelNext()
    {
        // Infinite loop over all levels
        if (currentLevelIndex >= levels.Count - 1)
        {
            currentLevelIndex = 0;
        }

        currentLevelIndex++;
        StartCoroutine(LoadLevelAsync(levels[currentLevelIndex], (scene) =>
        {
            loadedLevels.AddLast(scene);

            if (loadedLevels.Count > maxNumLoadedLevels)
            {
                // Move player to origin
                ResetOrigin();

                // Remove oldest scene
                Scene sceneToBeRemoved = loadedLevels.First();
                loadedLevels.RemoveFirst();
                StartCoroutine(UnloadSceneAsync(sceneToBeRemoved));
            }
        }));
    }

    private IEnumerator LoadLevelAsync(string sceneName, Action<Scene> callback)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
        Debug.Log($"{sceneName} loaded");

        Scene scene = SceneManager.GetSceneByName(sceneName);
        GameObject rootObject = scene.GetRootGameObjects().First();

        if (loadedLevels.Count > 0)
        {
            rootObject.transform.position = loadedLevels.Last().GetRootGameObjects().First().transform.position + Vector3.forward * LevelLength;
        }

        rootObject.SetActive(true);
        callback?.Invoke(scene);
    }

    private IEnumerator UnloadSceneAsync(Scene scene)
    {
        string name = scene.name;
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(scene);

        while (!asyncUnload.isDone)
        {
            yield return null;
        }
        Debug.Log($"{name} unloaded");
    }

    private void ResetOrigin()
    {
        if (player.position.z > 100)
        {
            Debug.Log("Reset origin");
            float offset = player.position.z;
            player.position = new Vector3(player.position.x, player.position.y, 0);

            foreach(Scene level in loadedLevels)
            {
                GameObject rootObject = level.GetRootGameObjects().First();
                rootObject.transform.position = rootObject.transform.position + Vector3.back * offset;
            }
        }
    }
}
