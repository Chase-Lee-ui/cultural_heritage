using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cmCamera;

    public void DisableCamera()
    {
        cmCamera.enabled = false;
    }
    public void EnableCamera()
    {
        cmCamera.enabled = true;
    }
}
