using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private GameObject bossToFollow;
    [SerializeField] private GameObject bossRevealCanvas;
    [SerializeField] private string bossText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var brain = m_camera.GetComponent<CinemachineBrain>();
            var vcam = (brain == null) ? null : brain.ActiveVirtualCamera as CinemachineVirtualCamera;
            if (vcam != null)
            {
                vcam.m_Lens.OrthographicSize = 18.0f;
                vcam.Follow = bossToFollow.transform;
            }
            GameObject bossCanvas = bossToFollow.transform.GetChild(0).gameObject;
            bossRevealCanvas.SetActive(true);
            SpriteRenderer grayScaleSprite = bossRevealCanvas.transform.GetChild(0).GetComponent<SpriteRenderer>();
            grayScaleSprite.color = new Color(1, 1, 1, 0.6f);
            bossRevealCanvas.GetComponent<SelfDestruct>().enabled = true;
            bossRevealCanvas.transform.GetChild(1).gameObject.SetActive(true);
            TextMeshProUGUI bossTextMesh = bossRevealCanvas.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            bossTextMesh.text = bossText;
            bossCanvas.SetActive(true);
            Destroy(gameObject);
        }
    }
}
