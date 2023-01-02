using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryText : MonoBehaviour
{
    AnimatedText animText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            animText = gameObject.GetComponent<AnimatedText>();
            animText.AnimateText(0.1f, "Press [X] for playing a memory");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
