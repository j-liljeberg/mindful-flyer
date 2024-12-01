using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] bool loadLevelOnStartUp = false;
    [SerializeField] List<GameObject> levels;

    private int currentLevelIndex = 0;
    private GameObject previousLevelInstance;
    private GameObject currentLevelInstance;
    private GameObject nextLevelInstance;

    void Start()
    {
        GameEvents.Instance.OnLoadNextLevel += LevelHalfway;
        GameEvents.Instance.OnLevelEnd += LevelEnd;

        if (loadLevelOnStartUp)
        {
            currentLevelInstance = LoadLevel(0, Vector3.zero);
        }
    }
    private void LevelHalfway()
    {
        LoadNextLevel();
        UnloadPreviousLevel();
    }

    private void LoadNextLevel()
    {
        Debug.Log("LoadNextLevel");
        currentLevelIndex++;
        Vector3 origin = Vector3.forward * 100 * currentLevelIndex;
        nextLevelInstance = LoadLevel(currentLevelIndex, origin);
    }

    private void UnloadPreviousLevel()
    {
        if (previousLevelInstance != null)
        {
            Destroy(previousLevelInstance);
        }
        previousLevelInstance = null;
    }

    private void LevelEnd()
    {
        Debug.Log("LevelEnd");
        previousLevelInstance = currentLevelInstance;
        currentLevelInstance = nextLevelInstance;
        nextLevelInstance = null;
    }

    private GameObject LoadLevel(int levelIndex, Vector3 origin)
    {
        if (levelIndex <= levels.Count - 1)
        {
            GameObject level = levels[levelIndex];

            if (level != null)
            {
                return Instantiate(level, origin, Quaternion.identity);
            }
        }
        return null;
    }
}
