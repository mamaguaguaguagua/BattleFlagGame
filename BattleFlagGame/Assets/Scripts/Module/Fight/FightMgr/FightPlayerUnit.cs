using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayerUnit : FightUnitBase
{
    public override void Init()
    {
        base.Init();
        //Debug.Log("��һغ�");
        GameApp.FightWorldManager.ResetEnemys();//���õ����ж�
        GameApp.ViewManager.Open(ViewType.TipView, "��һغ�");
    }
}
