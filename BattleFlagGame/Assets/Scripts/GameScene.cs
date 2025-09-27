using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 继承mono的脚本需要挂在游戏物体，跳转场景后当前脚本物体不删除
/// </summary>
public class GameScene : MonoBehaviour
{
    float dt;
    public Texture2D CursorPic;
    //跳转场景后物体不删除
    private static bool isLoaded = false;
    private void Awake()
    {
        if (isLoaded == true)
        {
            Destroy(gameObject);
        }
        else
        {
            isLoaded = true;
            DontDestroyOnLoad(gameObject);
            GameApp.Instance.Init();
        }

    }
    void Start()
    {
        //播放音乐
        GameApp.SoundManager.PlayBGM("login");
        Cursor.SetCursor(CursorPic, Vector2.zero, CursorMode.Auto);
        //注册配置表
        RegisterConfigs();
        GameApp.ConfigManager.LoadAllConfigs();
        //测试配置表
        //ConfigData tempdData = GameApp.ConfigManager.GetConFigData("enemy");
        //string name=tempdData.GetDataById(10001)["Name"];
        //Debug.Log(name);
        //注册游戏内的控制器
        RegisterModuel();//注册游戏内的控制器
        InitModule();
    }
    //注册控制器
    void RegisterModuel()
    {
        GameApp.ControllerManager.Register(ControllerType.GameUI, new GameUIController());
        GameApp.ControllerManager.Register(ControllerType.Game, new GameController());
        GameApp.ControllerManager.Register(ControllerType.Loading, new LoadingController());
        GameApp.ControllerManager.Register(ControllerType.Level, new LevelController());
        GameApp.ControllerManager.Register(ControllerType.Fight, new FightController());
    }
    //执行所有控制器的初始化
    void InitModule()
    {
        GameApp.ControllerManager.InitAllModules();
    }
    //注册配置表
    void RegisterConfigs()
    {
        GameApp.ConfigManager.Register("enemy", new ConfigData("enemy"));
        GameApp.ConfigManager.Register("level", new ConfigData("level"));
        GameApp.ConfigManager.Register("option", new ConfigData("option"));
        GameApp.ConfigManager.Register("player", new ConfigData("player"));
        GameApp.ConfigManager.Register("role", new ConfigData("role"));
        GameApp.ConfigManager.Register("skill", new ConfigData("skill"));
    }
    private void Update()
    {
        dt = Time.deltaTime;
        GameApp.Instance.Update(dt);
    }
}
