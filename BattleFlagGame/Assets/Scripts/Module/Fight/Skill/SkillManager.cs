using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager
{
    private GameTimer timer;//��ʱ��

    //skill:ʹ�õļ��ܣ�targets���ܵ�����Ŀ�� callback���ص�
    private Queue<(ISkill skill, List<ModelBase> targets, System.Action callback)> skills;//���ܶ���

    public SkillManager()
    {
        timer = new GameTimer();
        skills = new Queue<(ISkill skill, List<ModelBase> targets, System.Action callback)>();
    }

    //��Ӽ���
    public void AddSkill(ISkill skill, List<ModelBase> targets = null, System.Action callback = null)
    {
        skills.Enqueue((skill, targets, callback));
    }

    //ʹ�ü���
    public void UseSkill(ISkill skill, List<ModelBase> targets, System.Action callback)
    {
        ModelBase current = (ModelBase)skill;
        //����һ��Ŀ��
        if (targets.Count > 0)
        {
            current.LookAtModel(targets[0]);
        }
        current.PlaySound(skill.skillPro.Sound);//������Ч
        current.PlayAni(skill.skillPro.AniName);//���Ŷ���

        //�ӳٹ���
        timer.Register(skill.skillPro.AttackTime, delegate ()
        {
            //���ܵ�������ø���
            int atkCount = skill.skillPro.AttackCount >= targets.Count ? targets.Count : skill.skillPro.AttackCount;

            for (int i = 0; i < atkCount; i++)
            {
                targets[i].GetHit(skill);//����
            }
        });
        //���ܵĳ���ʱ��
        timer.Register(skill.skillPro.Time, delegate ()
        {
            //�ص�����
            current.PlayAni("idle");
            callback?.Invoke();//ִ�лص�
        });
    }

    public void Update(float dt)
    {
        timer.OnUpdate(dt);
        if (timer.Count() == 0 && skills.Count > 0)
        {
            //��һ��ʹ�õļ���
            var next = skills.Dequeue();
            if (next.targets != null)
            {
                UseSkill(next.skill, next.targets, next.callback);//ʹ�ü���
            }
        }
    }

    //ʹ��������һ������
    public bool IsRunningSkill()
    {
        if (timer.Count() == 0 && skills.Count == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //��ռ���
    public void Clear()
    {
        timer.Break();
        skills.Clear();
    }
}
