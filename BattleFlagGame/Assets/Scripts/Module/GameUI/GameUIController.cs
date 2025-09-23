using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������Ϸͨ��UI�Ŀ�������������� ��ʾ��� ��ʼ��Ϸ���������������ע�ᣩ
/// </summary>
public class GameUIController : BaseController
{
    public GameUIController() : base()
    {
        //ע����ͼ
        //��ʼ��Ϸ��ͼ
        GameApp.ViewManager.Register(ViewType.StartView, new ViewInfo()
        {
            PrefabName = "StartView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf
        });
        //�������
        GameApp.ViewManager.Register(ViewType.SetView, new ViewInfo()
        {
            PrefabName = "SetView",
            controller = this,
            Sorting_Order=1,//��ס��ʼ�������㼶��һ��
            parentTf = GameApp.ViewManager.canvasTf
        });
        //��ʾ���
        GameApp.ViewManager.Register(ViewType.MessageView, new ViewInfo()
        {
            PrefabName = "MessageView",
            controller = this,
            Sorting_Order = 999,
            parentTf = GameApp.ViewManager.canvasTf
        });
        InitModuleEvent();//��ʼ��ģ���¼�
        InitGlobalEvent();//��ʼ��ȫ���¼�
    }
    public override void InitModuleEvent()
    {
        RegisterFunc(Defines.OpenStartView, openStartView);//ע������
        RegisterFunc(Defines.OpenSetView, openSetView);//ע���������
        RegisterFunc(Defines.OpenMessageView, openMessageView);//����ʾ���
    }
    //����ģ��ע���¼� ����
    private void openStartView(System.Object[] arg)
    {
        GameApp.ViewManager.Open(ViewType.StartView, arg);
    }
    //���������
    private void openSetView(System.Object[] arg)
    {
        GameApp.ViewManager.Open(ViewType.SetView, arg);
    }
    //����ʾ���
    private void openMessageView(System.Object[] arg)
    {
        GameApp.ViewManager.Open(ViewType.MessageView, arg);
    }

}
