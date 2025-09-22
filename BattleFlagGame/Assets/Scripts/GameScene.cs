using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �̳�mono�Ľű���Ҫ������Ϸ����
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
        //��������
        GameApp.SoundManager.PlayBGM("login");
        Cursor.SetCursor(CursorPic, Vector2.zero, CursorMode.Auto);
        //ע����Ϸ�ڵĿ�����
        RegisterModuel();//ע����Ϸ�ڵĿ�����
        InitModule();
    }
    //ע�������
    void RegisterModuel()
    {
        GameApp.ControllerManager.Register(ControllerType.GameUI,new GameUIController());
        GameApp.ControllerManager.Register(ControllerType.Game, new GameController());
    }
    //ִ�����п������ĳ�ʼ��
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
