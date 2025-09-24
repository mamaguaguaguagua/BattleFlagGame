using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//¹Ø¿¨¿ØÖÆÆ÷
public class LevelController : BaseController
{
    public LevelController() : base()
    {
        GameApp.ViewManager.Register(ViewType.SelectLevelView, new ViewInfo()
        {
            PrefabName = "SelectLevelView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf
        }) ;
        InitModuleEvent();
    }
    public override void InitModuleEvent()
    {
        RegisterFunc(Defines.OpenSelectLevelView, onOpenSelectLevelView);
    }
    private void onOpenSelectLevelView(System.Object[] arg)
    {
        GameApp.ViewManager.Open(ViewType.SelectLevelView, arg);
    }
}
