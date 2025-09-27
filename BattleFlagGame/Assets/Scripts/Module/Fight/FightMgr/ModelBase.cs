using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBase : MonoBehaviour
{
    public int Id;//����id
    public Dictionary<string, string> data;//���ݱ�
    public int Step;//�ж���
    public int Attack;//������
    public int Type;//����
    public int MaxHp;//���Ѫ��
    public int CurHp;//��ǰѪ��

    public int RowIndex;
    public int ColIndex;
    public SpriteRenderer bodySp;//����ͼƬ��Ⱦ���
    public GameObject stopObj;//ֹͣ�ж��ı������
    public Animator ani;//�������

    private void Awake()
    {
        bodySp = transform.Find("body").GetComponent<SpriteRenderer>();
        stopObj = transform.Find("stop").gameObject;
        ani = transform.Find("body").GetComponent<Animator>();
    }
    protected virtual void Start()
    {
        AddEvents();
    }

    protected virtual void OnDestroy()
    {
        RemoveEvents();
    }

    //ע���¼�
    protected virtual void AddEvents()
    {
        GameApp.MsgCenter.AddEvent(gameObject, Defines.OnSelectEvent, OnSelectCallBack);
        GameApp.MsgCenter.AddEvent(Defines.OnUnSelectEvent, OnUnSelectCallBack);
    }

    //�Ƴ��¼�
    protected virtual void RemoveEvents()
    {
        GameApp.MsgCenter.RemoveEvent(gameObject, Defines.OnSelectEvent, OnSelectCallBack);
        GameApp.MsgCenter.RemoveEvent(Defines.OnUnSelectEvent, OnUnSelectCallBack);
    }

    //ѡ�лص�
    protected virtual void OnSelectCallBack(System.Object arg)
    {
        //ִ��δѡ��
        GameApp.MsgCenter.PostEvent(Defines.OnUnSelectEvent);
        //test
        //bodySp.color = Color.red;//���Ժ��û��Ҫ����
        GameApp.MapManager.ShowStepGrid(this, Step);
    }

    //δѡ�лص�
    protected virtual void OnUnSelectCallBack(System.Object arg)
    {
        //bodySp.color = Color.white;
        GameApp.MapManager.HideStepGrid(this, Step);
    }
}
