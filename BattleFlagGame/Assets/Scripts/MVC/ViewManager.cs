using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ViewInfo
{
    public string PrefabName;//��ͼԤ��������
    public Transform parentTf;//���ڸ���
    public BaseController controller;//��ͼ����������
    public int Sorting_Order;//��ʾ�㼶 ���ı���ʾ˳��
}
/// <summary>
/// ��ͼ������
/// </summary>
public class ViewManager 
{
    public Transform canvasTf;//����
    public Transform worldCanvasTf;//���续�����
    Dictionary<int, IBaseView> _opens;//�����е���ͼ 
    Dictionary<int, IBaseView> _viewCache;//��ͼ����
    Dictionary<int, ViewInfo> _views;//ע�����ͼ��Ϣ

    public ViewManager()
    {
        canvasTf = GameObject.Find("Canvas").transform;
        worldCanvasTf = GameObject.Find("WorldCanvas").transform;
        _opens = new Dictionary<int, IBaseView>();
        _views = new Dictionary<int, ViewInfo>();
        _viewCache = new Dictionary<int, IBaseView>();
    }
    //ע����ͼ��Ϣ
    public void Register(int key,ViewInfo viewInfo)
    {
        if (_views.ContainsKey(key) == false)
        {
            _views.Add(key, viewInfo);
        }
    }
    //�����ͼ��Ϣ
    public void Register(ViewType viewType,ViewInfo viewInfo)
    {
        Register((int)viewType, viewInfo);
    }
    //�Ƴ���ͼ��Ϣ
    public void UnRegister(int key)
    {
        if (_views.ContainsKey(key))
        {
            _views.Remove(key);
        }
    }
    //�Ƴ����
    public void RemoveView(int key)
    {
        _views.Remove(key);
        _viewCache.Remove(key);
        _opens.Remove(key);
    }
    //�Ƴ��������е����
    public void RemoveViewByController(BaseController ctl)
    {
        foreach(var item in _views)
        {
            if (item.Value.controller == ctl)
            {
                RemoveView(item.Key);
            }
        }
    }
    //�Ƿ�����
    public bool IsOpen(int key)
    {
        return _opens.ContainsKey(key);
    }
    //���ĳ����ͼ
    public IBaseView GetView(int key)
    {
        if (_opens.ContainsKey(key))
        {
            return _opens[key];
        }
        if (_viewCache.ContainsKey(key))
        {
            return _viewCache[key];
        }
        return null;
    }
    public T GetView<T>(int key) where T:class,IBaseView
    {
        IBaseView view = GetView(key);
        if (view != null)
        {
            return view as T;
        }
        return null; 
    }
    public void Destory(int key)
    {
        IBaseView oldView = GetView(key);
        if (oldView != null)
        {
            UnRegister(key);
            oldView.DestoryView();
            _viewCache.Remove(key);
        }
    }
    //�ر������ͼ
    public void Close(int key,params object[] args)
    {   //û�д�
        if (IsOpen(key) == false) return;
        IBaseView view = GetView(key);
        if (view != null)
        {
            _opens.Remove(key);
            view.Close(args);
            _views[key].controller.CloseView(view);
        }
    }
    public void CloseAll()
    {
        List<IBaseView> list = _opens.Values.ToList();
        for (int i = list.Count - 1; i >= 0; i--)
        {
            Close(list[i].ViewId);
        }
    }

    //�����
    public void Open(ViewType type, params object[] args)
    {
        Open((int)type, args);
    }
    public void Open(int key ,params object[] args)
    {
        IBaseView view = GetView(key);
        ViewInfo viewInfo = _views[key];
        if (view == null)
        {
            //�����ڵ���ͼ ������Դ����
            string type = ((ViewType)key).ToString();//���͵��ַ����ͽű����ƶ�Ӧ
            GameObject uiObj = UnityEngine.Object.Instantiate(Resources.Load($"View/{viewInfo.PrefabName}"), viewInfo.parentTf) as GameObject;
            Canvas canvas = uiObj.GetComponent<Canvas>();
            if (canvas == null)
            {
                canvas = uiObj.AddComponent<Canvas>();
            }
            if (uiObj.GetComponent<GraphicRaycaster>() == null)
            {
                uiObj.AddComponent<GraphicRaycaster>();
            }
            canvas.overrideSorting = true;//canvas�������ò㼶
            canvas.sortingOrder = viewInfo.Sorting_Order;//���ò㼶
            view = uiObj.AddComponent (Type.GetType(type))as IBaseView;//��Ӷ�Ӧ��View�ű�
            view.ViewId = key;//������ͼID
            view.Controller = viewInfo.controller;//���ÿ�����
            //��ӵ���ͼ����
            _viewCache.Add(key, view);
            viewInfo.controller.OnLoadView(view);
        }
        //�Ѿ�����
        if (this._opens.ContainsKey(key) == true)
        {
            return;
        }
        this._opens.Add(key, view);
        //�Ѿ���ʼ������
        if (view.IsInit())
        {
            view.SetVisible(true);//��ʾ
            view.Open(args);
            viewInfo.controller.OpenView(view);
        }
        else
        {
            //View��ʼ��
            view.InitUI();
            view.InitData();
            view.Open(args);
            viewInfo.controller.OpenView(view);
        }
    }
    //��ʾ�˺�����
    public void ShowHitNum(string num, Color color, Vector3 pos)
    {
        GameObject obj = UnityEngine.Object.Instantiate(Resources.Load("View/HitNum"), worldCanvasTf) as GameObject;
        obj.transform.position = pos;
        obj.transform.DOMove(pos + Vector3.up * 1.75f, 0.65f).SetEase(Ease.OutBack);
        UnityEngine.Object.Destroy(obj, 0.75f);
        Text hitTxt = obj.GetComponent<Text>();
        hitTxt.text = num;
        hitTxt.color = color;
    }
}
