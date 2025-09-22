using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ��ʼ��Ϸ����
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

    }
    private void OnSetBtn()
    {
        ApplyFunc(Defines.OpenSetView);
    }
    private void OnQuitBtn()
    {

    }
}
