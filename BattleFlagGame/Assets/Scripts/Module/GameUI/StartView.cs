using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 开始游戏界面
/// </summary>
public class StartView : BaseView
{
    protected override void OnAwake()
    {
        base.OnAwake();
        Find<Button>("startBtn").onClick.AddListener(OnStartGameBtn);
        Find<Button>("setBtn").onClick.AddListener(OnSetBtn);
        Find<Button>("quitBtn").onClick.AddListener(OnQuitBtn);
    }
    private void OnStartGameBtn()
    {
        //关闭开始界面
        GameApp.ViewManager.Close(ViewId);
        
        LoadingModel loadingModel = new LoadingModel();
        loadingModel.SceneName = "map";
        Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, loadingModel);
    }
    private void OnSetBtn()
    {
        ApplyFunc(Defines.OpenSetView);
    }
    private void OnQuitBtn()
    {
        Controller.ApplyControllerFunc(ControllerType.GameUI, Defines.OpenMessageView, new MessageInfo()
        {
            okCallback = delegate ()
            {
                Application.Quit();//退出游戏
            },
            MsgText = "确定退出游戏吗？"
        });
    }
}
