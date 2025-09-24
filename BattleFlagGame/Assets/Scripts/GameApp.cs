using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ͳһ������Ϸ�еĹ��������ڴ����н��г�ʼ��
/// </summary>
public class GameApp:Singleton<GameApp>
{
    public static SoundManager SoundManager;//��Ƶ������
    public static ControllerManager ControllerManager;//������������
    public static ViewManager ViewManager;//UI������
    public static ConfigManager ConfigManager;//���ݹ�����
    public static CameraManager CameraManager;//�����
    public override void Init()
    {
        CameraManager = new CameraManager();
        SoundManager = new SoundManager();
        ControllerManager = new ControllerManager();
        ViewManager = new ViewManager();
        ConfigManager = new ConfigManager();

    }
}
