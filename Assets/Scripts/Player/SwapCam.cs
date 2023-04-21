using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwapCam : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam1;
    [SerializeField] private CinemachineVirtualCamera vcam2;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(vcam1.Priority > vcam2.Priority)
            {
                vcam2.Priority += 10;
            }
            else
            {
                vcam2.Priority -= 10;
            }
        }
    }
}
