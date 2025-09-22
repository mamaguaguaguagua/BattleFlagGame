using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//设置音量面板
public class SetView : BaseView
{
    protected override void OnAwake()
    {
        base.OnAwake();
        Find<Button>("bg/closeBtn").onClick.AddListener(onCloseBtn);

    }
    //关闭按钮
    private void onCloseBtn()
    {
        GameApp.ViewManager.Close(ViewId);//关闭自己
    }
}
