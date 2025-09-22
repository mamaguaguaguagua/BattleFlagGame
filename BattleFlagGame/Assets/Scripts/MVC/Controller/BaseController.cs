using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制器基类
/// </summary>
public class BaseController
{
    private Dictionary<string, System.Action<object[]>> message;//事件字典

    protected BaseModel model;//数据模板

    public BaseController()
    {
        message = new Dictionary<string, System.Action<object[]>>();

    }
    //注册后调用的初始化函数（要所有控制器初始化后执行）
    public virtual void Init() { }
    public virtual void OnLoadView(IBaseView view) { }//加载视图
    //打开视图
    public virtual void OpenView(IBaseView view)
    {

    }
    //关闭视图
    public virtual void CloseView(IBaseView view)
    {

    }
    //注册模板事件
    public void RegisterFunc(string eventName, System.Action<object[]> callback)
    {
        if (message.ContainsKey(eventName))
        {
            message[eventName] += callback;
        }
        else
        {
            message.Add(eventName, callback);
        }
    }
    //移除模板事件
    public void UnRegisterFunc(string eventName)
    {
        if (message.ContainsKey(eventName))
        {
            message.Remove(eventName);
        }
    }
    //触发本模块事件 
    public void ApplyFunc(string eventName, params object[] args)
    {
        if (message.ContainsKey(eventName))
        {
            message[eventName].Invoke(args);
        }
        else
        {
            Debug.Log("error:" + eventName);
        }
    }
    //触发其他模板事件;例PlayerContorller得到InventoryController的方法
    public void ApplyControllerFunc(int controllerKey, string eventName, params object[] args)
    {

        GameApp.ControllerManager.ApllyFunc(controllerKey, eventName, args);
    }
    //执行所有控制器初始化
    public void ApplyControllerFunc(ControllerType type, string eventName, params object[] args)
    {
        ApplyControllerFunc((int)type, eventName, args);
    }



    //设置模型数据
    public void SetModel(BaseModel model)
    {
        this.model = model;
    }
    //得到模型
    public BaseModel GetModel()
    {
        return model;
    }
    public T GetModel<T>() where T : BaseModel
    {
        return model as T;
    }
    public BaseModel GetControllerModel(int controllerKey)//得到别的模型
    {
        return GameApp.ControllerManager.GetControllerModel(controllerKey);
    }
    public virtual void Destory()
    {

        RemoveModuleEvent();
        RemoveGlobalEvent();
    }
    //初始化模板事件
    public virtual void InitModuleEvent()
    {

    }
    //移除模板事件
    public virtual void RemoveModuleEvent()
    {

    }
    //初始化全局事件
    public virtual void InitGlobalEvent()
    {

    }
    //移除全局事件
    public virtual void RemoveGlobalEvent()
    {

    }


}
