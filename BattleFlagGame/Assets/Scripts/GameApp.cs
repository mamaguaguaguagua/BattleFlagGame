using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 统一定义游戏中的管理器，在此类中进行初始化
/// </summary>
public class GameApp : Singleton<GameApp>
{
    public static SoundManager SoundManager;//音频管理器
    public static ControllerManager ControllerManager;//控制器管理器
    public static ViewManager ViewManager;//UI管理器
    public static ConfigManager ConfigManager;//数据管理器
    public static CameraManager CameraManager;//摄像机
    public static MessageCenter MsgCenter;//消息监听
    public static TimerManager TimerManager;
    public static FightWorldManager FightWorldManager;
    //游戏数据管理器
    public static GameDataManager GameDataManager;

    //地图管理器
    public static MapManager MapManager;
    //用户的输入管理器
    public static UserInputManager UserInputManager;
    public override void Init()
    {
        TimerManager = new TimerManager();
        MsgCenter = new MessageCenter();
        CameraManager = new CameraManager();
        SoundManager = new SoundManager();
        ControllerManager = new ControllerManager();
        ViewManager = new ViewManager();
        ConfigManager = new ConfigManager();
        MapManager = new MapManager();
        FightWorldManager = new FightWorldManager();
        GameDataManager = new GameDataManager();
        UserInputManager = new UserInputManager();
    }

    public override void Update(float dt)
    {
        UserInputManager.Update();
        TimerManager.OnUpdate(dt);
        FightWorldManager.Update(dt);
    }
}
