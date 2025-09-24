using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager 
{
    private Transform camTF;//摄像机

    private Vector3 prePos;

    public CameraManager()
    {
        camTF = Camera.main.transform;
        prePos = camTF.transform.position;
    }
    //设置摄像机位置
    public void SetPos(Vector3 pos)
    {
        pos.z = camTF.position.z;
        camTF.transform.position = pos;
    }
    public void ResetPos()
    {
        camTF.transform.position = prePos;
    }
}
