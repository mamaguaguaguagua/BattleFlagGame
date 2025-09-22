using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 继承mono的脚本需要挂在游戏物体
/// </summary>
public class GameScene : MonoBehaviour
{
    float dt;
    public Texture2D CursorPic;
    private void Awake()
    {
        GameApp.Instance.Init();
    }
    void Start()
    {
        //播放音乐
        GameApp.SoundManager.PlayBGM("login");
        Cursor.SetCursor(CursorPic, Vector2.zero, CursorMode.Auto);
        //注册游戏内的控制器
        RegisterModuel();//注册游戏内的控制器
        InitModule();
    }
    //注册控制器
    void RegisterModuel()
    {
        GameApp.ControllerManager.Register(ControllerType.GameUI,new GameUIController());
        GameApp.ControllerManager.Register(ControllerType.Game, new GameController());
    }
    //执行所有控制器的初始化
    void InitModule()
    {
        GameApp.ControllerManager.InitAllModules();
    }
    private void Update()
    {
        dt = Time.deltaTime;
        GameApp.Instance.Update(dt);
    }
}
