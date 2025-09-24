using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 统一定义游戏中的管理器，在此类中进行初始化
/// </summary>
public class GameApp:Singleton<GameApp>
{
    public static SoundManager SoundManager;//音频管理器
    public static ControllerManager ControllerManager;//控制器管理器
    public static ViewManager ViewManager;//UI管理器
    public static ConfigManager ConfigManager;//数据管理器
    public static CameraManager CameraManager;//摄像机
    public override void Init()
    {
        CameraManager = new CameraManager();
        SoundManager = new SoundManager();
        ControllerManager = new ControllerManager();
        ViewManager = new ViewManager();
        ConfigManager = new ConfigManager();

    }
}
