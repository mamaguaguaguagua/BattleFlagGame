using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//选择关卡信息界面
public class SelectLevelView : BaseView
{
    protected override void OnStart()
    {
        base.OnStart();
        Find<Button>("close").onClick.AddListener(OnCloseBtn);
        Find<Button>("level/fightBtn").onClick.AddListener(OnFightBtn);
    }
    //返回开始场景
    private void OnCloseBtn()
    {
        //关闭关卡选择界面
        GameApp.ViewManager.Close(ViewId);

        LoadingModel loadingModel = new LoadingModel();
        loadingModel.SceneName = "game";
        loadingModel.callback = delegate ()
        {
            //打开开始界面

            Controller.ApplyControllerFunc(ControllerType.GameUI, Defines.OpenStartView);
        };
        Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, loadingModel);
    }
    //显示关卡面板
    public void ShowLevelDes()
    {
        Find("level").SetActive(true);
        LevelData current = Controller.GetModel<LevelModel>().current;
        Find<Text>("level/name/txt").text = current.Name;
        Find<Text>("level/des/txt").text = current.Des;
    }
    //隐藏关卡详情面板
    public void HideLevelDes()
    {
        Find("level").SetActive(false);
    }
    //切换到战斗场景
    private void OnFightBtn()
    {
        //关闭当前界面
        GameApp.ViewManager.Close(ViewId);
        //摄像机位置重置
        GameApp.CameraManager.ResetPos();

        LoadingModel loadingModel = new LoadingModel();
        loadingModel.SceneName = Controller.GetModel<LevelModel>().current.SceneName;//跳转的战斗场景
        loadingModel.callback = delegate ()
        {
            //成功加载后显示战斗界面
            Controller.ApplyControllerFunc(ControllerType.Fight, Defines.BeginFight);
        };
        Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, loadingModel);
    }
}
