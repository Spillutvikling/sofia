using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTrigger : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        var playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            var nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
            var totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;

            if (nextIndex >= totalNumberOfScenes)
            {
                Debug.LogError($"Tried to load scene index {nextIndex}, but there are only {totalNumberOfScenes} scenes in build config.");
                return;
            }

            SceneManager.LoadScene(nextIndex);
        }
    }
}
