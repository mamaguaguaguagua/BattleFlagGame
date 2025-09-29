using UnityEngine.UI;

public class LossView : BaseView
{
    protected override void OnStart()
    {
        base.OnStart();
        //注意查看预制体文件，胜利和失败的层次结构不一样的
        Find<Button>("okBtn").onClick.AddListener(delegate ()
        {
            //卸载战斗中的资源
            GameApp.FightWorldManager.ReLoadRes();
            GameApp.ViewManager.CloseAll();

            //切换场景
            LoadingModel load = new LoadingModel();
            load.SceneName = "map";
            load.callback = delegate ()
            {
                GameApp.SoundManager.PlayBGM("mapbgm");
                GameApp.ViewManager.Open(ViewType.SelectLevelView);
            };
            Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, load);
        });
    }
}