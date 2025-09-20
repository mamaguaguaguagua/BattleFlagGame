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
    }
    private void Update()
    {
        dt = Time.deltaTime;
        GameApp.Instance.Update(dt);
    }
}
