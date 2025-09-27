using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �̳�mono�Ľű���Ҫ������Ϸ���壬��ת������ǰ�ű����岻ɾ��
/// </summary>
public class GameScene : MonoBehaviour
{
    float dt;
    public Texture2D CursorPic;
    //��ת���������岻ɾ��
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
        //��������
        GameApp.SoundManager.PlayBGM("login");
        Cursor.SetCursor(CursorPic, Vector2.zero, CursorMode.Auto);
        //ע�����ñ�
        RegisterConfigs();
        GameApp.ConfigManager.LoadAllConfigs();
        //�������ñ�
        //ConfigData tempdData = GameApp.ConfigManager.GetConFigData("enemy");
        //string name=tempdData.GetDataById(10001)["Name"];
        //Debug.Log(name);
        //ע����Ϸ�ڵĿ�����
        RegisterModuel();//ע����Ϸ�ڵĿ�����
        InitModule();
    }
    //ע�������
    void RegisterModuel()
    {
        GameApp.ControllerManager.Register(ControllerType.GameUI, new GameUIController());
        GameApp.ControllerManager.Register(ControllerType.Game, new GameController());
        GameApp.ControllerManager.Register(ControllerType.Loading, new LoadingController());
        GameApp.ControllerManager.Register(ControllerType.Level, new LevelController());
        GameApp.ControllerManager.Register(ControllerType.Fight, new FightController());
    }
    //ִ�����п������ĳ�ʼ��
    void InitModule()
    {
        GameApp.ControllerManager.InitAllModules();
    }
    //ע�����ñ�
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
