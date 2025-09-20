using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// 控制器管理器
/// </summary>
public class ControllerManager 
{
    private Dictionary<int, BaseController> _modules;//存储控制器的字典

    public ControllerManager()
    {
        _modules = new Dictionary<int, BaseController>();
    }
    //注册控制器
    public void Register(int controllerKey, BaseController ctl)
    {
        if (_modules.ContainsKey(controllerKey) == false)
        {
            _modules.Add(controllerKey, ctl);
        }
    }
    //移除控制器
    public void UnRegister(int controllerKey)
    {
        if (_modules.ContainsKey(controllerKey))
        {
            _modules.Remove(controllerKey);
        }
    }
    //清楚字典 
    public void Clear()
    {
        _modules.Clear();
    }
    //清除所有控制器
    public void ClearAllModules()
    {
       List<int> keys= _modules.Keys.ToList();
        for (int i = 0; i < keys.Count; i++)
        {
            _modules[keys[i]].Destory();
            _modules.Remove(keys[i]);
        }
    }
    //跨模板触发消息
    public void  ApllyFunc(int controllerKey,string  eventName,System.Object[] args)
    {
        if (_modules.ContainsKey(controllerKey))
        {
            _modules[controllerKey].ApplyFunc(eventName, args);
        }

    }
    //获取某控制器的Model对象
    public BaseModel GetControllerModel(int controllerKey)
    {
        if (_modules.ContainsKey(controllerKey))
        {
            return _modules[controllerKey].GetModel();
        }
        else
        {
            return null;
        }
    }
}
