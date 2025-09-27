using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ͳһ������Ϸ�еĹ��������ڴ����н��г�ʼ��
/// </summary>
public class GameApp : Singleton<GameApp>
{
    public static SoundManager SoundManager;//��Ƶ������
    public static ControllerManager ControllerManager;//������������
    public static ViewManager ViewManager;//UI������
    public static ConfigManager ConfigManager;//���ݹ�����
    public static CameraManager CameraManager;//�����
    public static MessageCenter MsgCenter;//��Ϣ����
    public static TimerManager TimerManager;
    public static FightWorldManager FightWorldManager;
    //��Ϸ���ݹ�����
    public static GameDataManager GameDataManager;

    //��ͼ������
    public static MapManager MapManager;
    //�û������������
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
