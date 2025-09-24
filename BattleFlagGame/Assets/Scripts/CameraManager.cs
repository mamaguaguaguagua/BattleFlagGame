using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager 
{
    private Transform camTF;//�����

    private Vector3 prePos;

    public CameraManager()
    {
        camTF = Camera.main.transform;
        prePos = camTF.transform.position;
    }
    //���������λ��
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
