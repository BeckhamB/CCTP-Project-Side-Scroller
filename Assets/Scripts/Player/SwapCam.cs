using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwapCam : MonoBehaviour
{
    private CinemachineVirtualCamera vcam1;

    private void Start()
    {
        vcam1 = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(vcam1.m_Lens.OrthographicSize > 10)
            {
                vcam1.m_Lens.OrthographicSize = 5;
            }
            else
            {
                vcam1.m_Lens.OrthographicSize = 80;
            }
        }
    }
}
