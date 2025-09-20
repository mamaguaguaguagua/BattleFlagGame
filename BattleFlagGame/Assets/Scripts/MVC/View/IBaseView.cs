using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//视图接口，视图要继承MonoBehaviour
public interface  IBaseView 
{
    #region 状态查询方法
    bool IsInit();//视图是否初始化
    bool IsShow();//是否显示
    #endregion
    #region 生命周期管理
    void InitUI();//初始面板
    void InitData();//初始化数据
    void Open(params object[] args);//打开面板，变长参数
    void Close(params object[] args);//关闭面板
    void DestoryView();//删除面板
    #endregion

    void ApplyFunc(string eventName, params object[] args);//触发本模块事件
    void ApplyControllerFunc(int controllerKey, string eventName, params object[] args);//触发其他控制器模块事件
    void SetVisible(bool value);//设置显隐
    int ViewId { get; set; }//面板Id

    BaseController Controller { get; set; }//面板所属控制器


}
