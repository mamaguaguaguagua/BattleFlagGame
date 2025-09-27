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


        InitModuleEvent();
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
