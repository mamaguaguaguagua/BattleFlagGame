using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�����������
public class SetView : BaseView
{
    protected override void OnAwake()
    {
        base.OnAwake();
        Find<Button>("bg/closeBtn").onClick.AddListener(onCloseBtn);

    }
    //�رհ�ť
    private void onCloseBtn()
    {
        GameApp.ViewManager.Close(ViewId);//�ر��Լ�
    }
}
