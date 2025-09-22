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
            parentTf = GameApp.ViewManager.canvasTf
        });
        InitModuleEvent();//��ʼ��ģ���¼�
        InitGlobalEvent();//��ʼ��ȫ���¼�
    }
    public override void InitModuleEvent()
    {
        RegisterFunc(Defines.OpenStartView, openStartView);//ע������
        RegisterFunc(Defines.OpenSetView, openSetView);//ע���������
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

}
