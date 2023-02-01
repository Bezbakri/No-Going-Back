using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchBetweenDialogueScenes : MonoBehaviour
{
    private List<string> sceneNames = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(string sceneName)
    {
        sceneNames.Add(SceneManager.GetActiveScene().name);
        sceneNames.Add(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public bool ReturnToPreviousScene()
    {
        bool returnValue = false;
        if (sceneNames.Count > 1)
        {
            returnValue = true;
            sceneNames.RemoveAt(sceneNames.Count - 1);
            SceneManager.LoadScene(sceneNames[sceneNames.Count - 1]);
        }
        return returnValue;
    }
}
