using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��Ϣ��������
/// </summary>
public class MessageCenter 
{
    private Dictionary<string, System.Action<object>> msgDic;//�洢��ͨ����Ϣ�ֵ�
    private Dictionary<string, System.Action<object>> tempMsgDic;//�洢��ʱ����Ϣ�ֵ䣬ʩ�к��Ƴ�
    private Dictionary<System.Object, Dictionary<string, System.Action<object>>> objMsgDic;//�洢�ض��������Ϣ�ֵ�

    public MessageCenter()
    {
        msgDic = new Dictionary<string, System.Action<object>>();
        tempMsgDic = new Dictionary<string, System.Action<object>>();
        objMsgDic = new Dictionary<object, Dictionary<string, System.Action<object>>>();
    }
    public void AddEvent(string eventName,System.Action<object> callback)
    {
        if (msgDic.ContainsKey(eventName))
        {
            msgDic[eventName] += callback;
        }
        else
        {
            msgDic.Add(eventName, callback);
        }
    }
    //�Ƴ��¼�
    public void RemoveEvent(string eventName,System.Action<object> callback)
    {
        if (msgDic.ContainsKey(eventName))
        {
            msgDic[eventName] -= callback;
            if (msgDic[eventName] == null)
            {
                msgDic.Remove(eventName);
            }
        }
    }
    //ִ���¼�
    public void PostEvent(string eventName,object arg = null)
    {
        if (msgDic.ContainsKey(eventName))
        {
            msgDic[eventName].Invoke(arg);
        }
    }
    //��Ӷ����¼�
    public void AddEvent(System.Object listenerObj,string eventName,System.Action<object> callback)
    {
        if (objMsgDic.ContainsKey(listenerObj))
        {
            if (objMsgDic[listenerObj].ContainsKey(eventName))
            {
                objMsgDic[listenerObj][eventName] += callback;
            }
            else
            {
                objMsgDic[listenerObj].Add(eventName, callback);
            }
        }
        else
        {
            Dictionary<string, System.Action<object>> _tempDic = new Dictionary<string, System.Action<object>>();
            _tempDic.Add(eventName, callback);
            objMsgDic.Add(listenerObj, _tempDic);
        }
    }
    //�Ƴ������¼�
    public void RemoveEvent(System.Object listenerObj, string eventName, System.Action<object> callback)
    {
        if (objMsgDic.ContainsKey(listenerObj))
        {
            if (objMsgDic[listenerObj].ContainsKey(eventName))
            {
                objMsgDic[listenerObj][eventName] -= callback;
                if (objMsgDic[listenerObj][eventName] == null)
                {
                    objMsgDic[listenerObj].Remove(eventName);
                    if (objMsgDic[listenerObj].Count == 0)
                    {
                        objMsgDic.Remove(listenerObj);
                    }
                }
            }
        }
    }
    //�Ƴ�����������¼�
    public void RemoveObjAllEvent(System.Object listenerObj)
    {
        if (objMsgDic.ContainsKey(listenerObj))
        {
            objMsgDic.Remove(listenerObj);
        }
    }
    //ִ�ж���ļ����¼�
    public void PostEvent(System.Object listenerObj, string eventName, System.Object arg = null)
    {
        if (objMsgDic.ContainsKey(listenerObj))
        {
            if (objMsgDic[listenerObj].ContainsKey(eventName))
            {
                objMsgDic[listenerObj][eventName].Invoke(arg);
            }
        }
    }
    
    public void AddTempEvent(string eventName, System.Action<object> callback)
    {
        if (tempMsgDic.ContainsKey(eventName))
        {
            //�����ʱ�¼���Ȼ�󱻸��ǵ��������ۼӵ�
            tempMsgDic[eventName] = callback;
        }
        else
        {
            tempMsgDic.Add(eventName, callback);
        }
    }
    public void PostTempEvent(string eventName, System.Object arg = null)
    {
        if (tempMsgDic.ContainsKey(eventName))
        {
            tempMsgDic[eventName].Invoke(arg);
            tempMsgDic[eventName] = null;
            tempMsgDic.Remove(eventName);
        }
    }
}
