using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{

    public CinemachineVirtualCamera playCam;
    public CinemachineVirtualCamera staticCam;


    private void Start()
    {
        PlayCam();
        GameManager.Fail += StaticCam;
        GameManager.Success += StaticCam;
    }

    public void PlayCam()
    {
        playCam.Priority = 10;
        staticCam.Priority = 9;

    }
    public void StaticCam()
    {
        playCam.Priority = 9;
        staticCam.Priority = 10;

    }


}
