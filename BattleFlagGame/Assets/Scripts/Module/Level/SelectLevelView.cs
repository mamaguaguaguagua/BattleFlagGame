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
        Find<Button>("level/fightBtn").onClick.AddListener(OnFightBtn);
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
    //��ʾ�ؿ����
    public void ShowLevelDes()
    {
        Find("level").SetActive(true);
        LevelData current = Controller.GetModel<LevelModel>().current;
        Find<Text>("level/name/txt").text = current.Name;
        Find<Text>("level/des/txt").text = current.Des;
    }
    //���عؿ��������
    public void HideLevelDes()
    {
        Find("level").SetActive(false);
    }
    //�л���ս������
    private void OnFightBtn()
    {
        //�رյ�ǰ����
        GameApp.ViewManager.Close(ViewId);
        //�����λ������
        GameApp.CameraManager.ResetPos();

        LoadingModel loadingModel = new LoadingModel();
        loadingModel.SceneName = Controller.GetModel<LevelModel>().current.SceneName;//��ת��ս������
        loadingModel.callback = delegate ()
        {
            //�ɹ����غ���ʾս������
            Controller.ApplyControllerFunc(ControllerType.Fight, Defines.BeginFight);
        };
        Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, loadingModel);
    }
}
