using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���˻غ�
/// </summary>
public class FightEnemyUnit : FightUnitBase
{
    public override void Init()
    {
        base.Init();
        GameApp.FightWorldManager.ResetHeros();//����Ӣ���ж�
        GameApp.ViewManager.Open(ViewType.TipView, "���˻غ�");

        //�ȴ���ʱ��Ҫ��΢�ӳ�һЩ��̫�̻�������⣬�޷��غ��л�
        GameApp.CommandManager.AddCommand(new WaitCommand(1.25f));

        //�����ƶ���ʹ�ü��ܵ�
        for (int i = 0; i < GameApp.FightWorldManager.enemys.Count; i++)
        {
            Enemy enemy = GameApp.FightWorldManager.enemys[i];
            GameApp.CommandManager.AddCommand(new WaitCommand(0.25f));//�ȴ�
            GameApp.CommandManager.AddCommand(new AiMoveCommand(enemy));//�ƶ�
            GameApp.CommandManager.AddCommand(new WaitCommand(0.25f));//�ȴ�
            GameApp.CommandManager.AddCommand(new SkillCommand(enemy));//ʹ�ü���
            GameApp.CommandManager.AddCommand(new WaitCommand(0.25f));//�ȴ�
        }

        //�ȴ�һ��ʱ�䣬�л�����һغ�
        GameApp.CommandManager.AddCommand(new WaitCommand(0.2f, delegate ()
        {
            GameApp.FightWorldManager.ChangeState(GameState.Player);
        }));
    }
}
