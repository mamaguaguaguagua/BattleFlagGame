using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <summary>
/// ������ࣨ���������ƶ���ʹ�ü��ܵȣ�
/// </summary>
public class BaseCommand
{
    public ModelBase model;//����Ķ���
    protected bool isFinish;//�Ƿ�������

    public BaseCommand()
    {

    }

    public BaseCommand(ModelBase model)
    {
        this.model = model;
        isFinish = false;
    }

    public virtual bool Update(float dt)
    {
        return isFinish;
    }

    //ִ������
    public virtual void Do()
    {

    }

    //��������
    public virtual void UnDo()
    {

    }
}