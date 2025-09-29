using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ս����������ս����ؽ��� �¼��ȣ�
/// </summary>
public class FightController : BaseController
{

    public FightController() : base()
    {
        //����ս������ģ��
        SetModel(new FightModel(this));

        GameApp.ViewManager.Register(ViewType.FightView, new ViewInfo()
        {
            PrefabName = "FightView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf

        }) ;
        GameApp.ViewManager.Register(ViewType.FightSelectHeroView, new ViewInfo()
        {
            PrefabName = "FightSelectHeroView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 1
        }) ;
        GameApp.ViewManager.Register(ViewType.DragHeroView ,new ViewInfo()
        {
            PrefabName = "DragHeroView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 2
        });
        GameApp.ViewManager.Register(ViewType.TipView, new ViewInfo()
        {
            PrefabName = "TipView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 2
        });
        //ע��Ӣ��/������Ϣ��壬���ض�Ӧ��Ԥ�����ļ�
        GameApp.ViewManager.Register(ViewType.HeroDesView, new ViewInfo()
        {
            PrefabName = "HeroDesView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 2
        });
        GameApp.ViewManager.Register(ViewType.EnemyDesView, new ViewInfo()
        {
            PrefabName = "EnemyDesView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 2
        });
        //ѡ��������
        GameApp.ViewManager.Register(ViewType.SelectOptionView, new ViewInfo()
        {
            PrefabName = "SelectOptionView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf
        });
        //ս������ѡ�����
        GameApp.ViewManager.Register(ViewType.FightOptionDesView, new ViewInfo()
        {
            PrefabName = "FightOptionDesView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 3
        });
        //ʤ����ʧ�ܵĴ���
        GameApp.ViewManager.Register(ViewType.WinView, new ViewInfo()
        {
            PrefabName = "WinView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 3
        });
        GameApp.ViewManager.Register(ViewType.LossView, new ViewInfo()
        {
            PrefabName = "LossView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 3
        });
        InitModuleEvent();
    }
    //��ʼ��
    public override void Init()
    {
        base.Init();
        model.Init();
    }

    public override void InitModuleEvent()
    {
        RegisterFunc(Defines.BeginFight, onBeginFightCallBack);
    }
    private void onBeginFightCallBack(System.Object[] arg)
    {
        //����ս��
        GameApp.FightWorldManager.ChangeState(GameState.Enter);

        GameApp.ViewManager.Open(ViewType.FightView);
        GameApp.ViewManager.Open(ViewType.FightSelectHeroView);
    }
}
