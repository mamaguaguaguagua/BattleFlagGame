using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 单例
/// </summary>
public class Singleton<T>
{
    private static readonly T instance = Activator.CreateInstance<T>();//泛型对象无法直接new用反射机制创建一个instance，不知继承单例的是否有无参我构造，否则可以用new（）
    public static T Instance
    {
        get { return instance; }

    }
    //初始化
    public virtual void Init()
    {

    }
    //每帧执行的
    public virtual void Update(float dt)
    {

    }
    //释放
    public virtual  void OnDestory()
    {

    }
}
