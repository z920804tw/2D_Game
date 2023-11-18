using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using Cinemachine;

public class CameraControll : MonoBehaviour
{
    [Header("玩家設定")]
    //public Transform playerTransform;
    
    CinemachineVirtualCamera vCam;
    float camZ;
    // Start is called before the first frame update
    void Start()
    {
        
        vCam=GetComponent<CinemachineVirtualCamera>();
        camZ=vCam.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        CamZoomInput();
       // transform.position= new Vector3(playerTransform.position.x, 0, transform.position.z);
        
    }
    void CamZoomInput()       //攝影機的縮放控制
    {
        float mouseScroll = Input.GetAxisRaw("Mouse ScrollWheel");
        camZ-=mouseScroll;
        camZ=Mathf.Clamp(camZ, 3f,5f);                           //限制最小3最大5
        
        vCam.m_Lens.OrthographicSize=camZ;
        //transform.position = new Vector3(transform.position.x, transform.position.y, camZ);

    }
}
