using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ����
/// </summary>
public class Singleton<T>
{
    private static readonly T instance = Activator.CreateInstance<T>();//���Ͷ����޷�ֱ��new�÷�����ƴ���һ��instance����֪�̳е������Ƿ����޲��ҹ��죬���������new����
    public static T Instance
    {
        get { return instance; }

    }
    //��ʼ��
    public virtual void Init()
    {

    }
    //ÿִ֡�е�
    public virtual void Update(float dt)
    {

    }
    //�ͷ�
    public virtual  void OnDestory()
    {

    }
}
