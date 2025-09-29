using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 战斗控制器（战斗相关界面 事件等）
/// </summary>
public class FightController : BaseController
{

    public FightController() : base()
    {
        //设置战斗数据模块
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
        //注册英雄/敌人信息面板，加载对应的预制体文件
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
        //选项界面面板
        GameApp.ViewManager.Register(ViewType.SelectOptionView, new ViewInfo()
        {
            PrefabName = "SelectOptionView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf
        });
        //战斗界面选项面板
        GameApp.ViewManager.Register(ViewType.FightOptionDesView, new ViewInfo()
        {
            PrefabName = "FightOptionDesView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf,
            Sorting_Order = 3
        });
        //胜利和失败的窗口
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
    //初始化
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
        //进入战斗
        GameApp.FightWorldManager.ChangeState(GameState.Enter);

        GameApp.ViewManager.Open(ViewType.FightView);
        GameApp.ViewManager.Open(ViewType.FightSelectHeroView);
    }
}
