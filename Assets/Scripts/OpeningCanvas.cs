using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningCanvas : MonoBehaviour
{
    [SerializeField] private Image openingImage;
    public float loadTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        openingImage.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        openingImage.fillAmount -= 1.0f / loadTime * Time.deltaTime;
        if (openingImage.fillAmount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
