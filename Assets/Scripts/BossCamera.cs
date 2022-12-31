using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private GameObject bossToFollow;
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
            bossCanvas.SetActive(true);
        }
    }
}
