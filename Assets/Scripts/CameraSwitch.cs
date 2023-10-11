using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{

    public CinemachineVirtualCamera playCam;
    public CinemachineVirtualCamera staticCam;
    public CinemachineVirtualCamera startCam;

    private void Start()
    {
      
        StartCam();
    }

    public void PlayCam()
    {
        playCam.Priority += 10;
        staticCam.Priority -= 10;
        startCam.Priority -= 10;
    }
    public void StaticCam()
    {
        playCam.Priority -= 10;
        staticCam.Priority += 10;
        startCam.Priority -= 10;
    }
    public void StartCam()
    {
        playCam.Priority -= 10;
        staticCam.Priority -= 10;
        startCam.Priority += 10;
    }

}
