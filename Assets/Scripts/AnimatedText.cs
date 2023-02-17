using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimatedText : MonoBehaviour
{
    public delegate void AnimatedTextCompleteted();
    public event AnimatedTextCompleteted OnAnimatedTextCompleted;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI displayedText;
    [SerializeField] private float delayBetweenLetters = 0.05f;

    [SerializeField] private AudioClip _audioSource;

    private string textToAnimate;
    private string currentText;

    private char[] splitMessage;
    private int indexChar = 0;
    private char previousChar;

    private void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = _audioSource;
    }

    public void AnimateText(float startDelay, string text)
    {
        textToAnimate = text;
        displayedText.text = "";
        splitMessage = text.ToCharArray();
        StartCoroutine(StartAnimation(startDelay));
    }


    public IEnumerator StartAnimation(float startDelay)
    {
        yield return new WaitForSeconds(startDelay);

        indexChar = 0;

        currentText = "";

        // Store first letter
        previousChar = splitMessage[0];
        displayedText.text = "<i><color=yellow>" + splitMessage[indexChar] + "</color></i>";
        if (_audioSource != null)
        {
            GetComponent<AudioSource>().Play();
        }

        indexChar = 1;
        while(indexChar < splitMessage.Length)
        {
            yield return new WaitForSeconds(delayBetweenLetters);

            // Add text
            currentText += previousChar;
            displayedText.text = currentText + "<i><color=yellow>" + splitMessage[indexChar] + "</color></i>";

            // Play sound
            if (_audioSource != null)
            {
                GetComponent<AudioSource>().Play();
            }

            // Save previous char
            previousChar = splitMessage[indexChar];
            indexChar++;
        }

        yield return new WaitForSeconds(delayBetweenLetters);
        displayedText.text = textToAnimate;

        if (OnAnimatedTextCompleted != null)
        {
            OnAnimatedTextCompleted();
        }
    }
}
