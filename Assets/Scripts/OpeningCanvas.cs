using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningCanvas : MonoBehaviour
{
    [SerializeField] private Image openingImage;
    public float loadTime = 2f;
    private bool startAnimation = false;

    // Start is called before the first frame update
    void Start()
    {
        openingImage.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(pauseGame());
        if (startAnimation)
        {
            openingImage.fillAmount -= 1.0f / loadTime * Time.unscaledDeltaTime;
            if (openingImage.fillAmount <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 1.0f;
            }
        }
    }

    private IEnumerator pauseGame()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(loadTime);
        startAnimation = true;
    }
}
