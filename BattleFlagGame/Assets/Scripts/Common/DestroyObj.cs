using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �Զ�ɾ������
/// </summary>
public class DestroyObj : MonoBehaviour
{
    public float timer;
    private void Start()
    {
        Destroy(gameObject, timer);
    }
}
