using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    [SerializeField] private string scene;
    [SerializeField] private GameObject closingCanvasPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject closingCanvas = Instantiate(closingCanvasPrefab);
            StartCoroutine(LoadingScene());
        }
    }
    private IEnumerator LoadingScene()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }
}
