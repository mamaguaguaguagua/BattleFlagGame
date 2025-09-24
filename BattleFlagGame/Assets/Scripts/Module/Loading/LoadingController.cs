using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//���س���������
public class LoadingController : BaseController
{
    AsyncOperation asyncOp;
    public LoadingController() : base()
    {
        GameApp.ViewManager.Register(ViewType.LoadingView, new ViewInfo()
        {
            PrefabName = "LoadingView",
            controller = this,
            parentTf = GameApp.ViewManager.canvasTf
        }
            );
        InitModuleEvent();
    }
    public override void InitModuleEvent()
    {
        RegisterFunc(Defines.LoadingScene, loadSceneCallBack);
    }
    //���س����ص�
    private void loadSceneCallBack(params object[] args)
    {
        LoadingModel loadingModel = args[0] as LoadingModel;
        SetModel(loadingModel);

        //�򿪼��ؽ���
        GameApp.ViewManager.Open(ViewType.LoadingView);
        //���� ����
        asyncOp = SceneManager.LoadSceneAsync(loadingModel.SceneName);
        asyncOp.completed += onLoadedEndCallBack;
    }
    //���غ�ص�
    private void onLoadedEndCallBack(AsyncOperation op)
    {
        asyncOp.completed -= onLoadedEndCallBack;

        GetModel<LoadingModel>().callback?.Invoke();//ִ�лص�

        GameApp.ViewManager.Close((int)ViewType.LoadingView);//�رռ��ؽ���
    }
}
