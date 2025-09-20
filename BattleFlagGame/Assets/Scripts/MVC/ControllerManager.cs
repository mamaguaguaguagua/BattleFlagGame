using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// ������������
/// </summary>
public class ControllerManager 
{
    private Dictionary<int, BaseController> _modules;//�洢���������ֵ�

    public ControllerManager()
    {
        _modules = new Dictionary<int, BaseController>();
    }
    //ע�������
    public void Register(int controllerKey, BaseController ctl)
    {
        if (_modules.ContainsKey(controllerKey) == false)
        {
            _modules.Add(controllerKey, ctl);
        }
    }
    //�Ƴ�������
    public void UnRegister(int controllerKey)
    {
        if (_modules.ContainsKey(controllerKey))
        {
            _modules.Remove(controllerKey);
        }
    }
    //����ֵ� 
    public void Clear()
    {
        _modules.Clear();
    }
    //������п�����
    public void ClearAllModules()
    {
       List<int> keys= _modules.Keys.ToList();
        for (int i = 0; i < keys.Count; i++)
        {
            _modules[keys[i]].Destory();
            _modules.Remove(keys[i]);
        }
    }
    //��ģ�崥����Ϣ
    public void  ApllyFunc(int controllerKey,string  eventName,System.Object[] args)
    {
        if (_modules.ContainsKey(controllerKey))
        {
            _modules[controllerKey].ApplyFunc(eventName, args);
        }

    }
    //��ȡĳ��������Model����
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
