using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosingCanvas : MonoBehaviour
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
        openingImage.fillAmount += 1.0f / loadTime * Time.unscaledDeltaTime;
    }
}
