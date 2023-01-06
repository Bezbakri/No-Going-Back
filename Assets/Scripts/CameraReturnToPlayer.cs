using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReturnToPlayer : MonoBehaviour
{

    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject player;
    [SerializeField] private Camera m_camera;

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
        {
            var brain = m_camera.GetComponent<CinemachineBrain>();
            var vcam = (brain == null) ? null : brain.ActiveVirtualCamera as CinemachineVirtualCamera;
            if (vcam != null)
            {
                vcam.m_Lens.OrthographicSize = 10.0f;
                vcam.Follow = player.transform;
            }
        }
    }
}
