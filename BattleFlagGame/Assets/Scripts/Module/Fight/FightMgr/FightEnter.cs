using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ս������Ҫ������߼�
/// </summary>
public class FightEnter : FightUnitBase
{
    public override void Init()
    {
        //��ͼ��ʼ��
        GameApp.MapManager.Init();
        //����ս��
        GameApp.FightWorldManager.EnterFight();
    }
}
