using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMenu : MonoBehaviour {
    private const int BUTTON_WIDTH = 300;
    private const int BUTTON_HEIGHT = 50;

    private void OnGUI()
    {
        var w = Screen.width;
        var h = Screen.height;
        const int offset = 10;
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        for (var i = 0; i < sceneCount; i++)
        {
            if (i == SceneManager.GetActiveScene().buildIndex)
                continue;
            if (GUI.Button(new Rect(w / 2 - BUTTON_WIDTH / 2, h / 2 - BUTTON_HEIGHT / 2 - (BUTTON_HEIGHT + offset) * (sceneCount / 2) + (BUTTON_HEIGHT + offset) * i, BUTTON_WIDTH, BUTTON_HEIGHT), "Cargar 'Escena" + i + "'"))
                EventManager.CurrentEventManager.EnqueueAction(new LoadSceneAction(i));
        }
    }
}
