using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//ѡ��ؿ���Ϣ����
public class SelectLevelView : BaseView
{
    protected override void OnStart()
    {
        base.OnStart();
        Find<Button>("close").onClick.AddListener(OnCloseBtn);
    }
    //���ؿ�ʼ����
    private void OnCloseBtn()
    {
        //�رչؿ�ѡ�����
        GameApp.ViewManager.Close(ViewId);

        LoadingModel loadingModel = new LoadingModel();
        loadingModel.SceneName = "game";
        loadingModel.callback = delegate ()
        {
            //�򿪿�ʼ����

            Controller.ApplyControllerFunc(ControllerType.GameUI, Defines.OpenStartView);
        };
        Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, loadingModel);
    }
}
