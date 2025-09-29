using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
/// <summary>
/// ���ܰ�����
/// </summary>
public static class SkillHelper
{
    //Ŀ���Ƿ��ڼ��ܵ�����Χ��
    public static bool IsModelInSkillArea(this ISkill skill, ModelBase target)
    {
        ModelBase current = (ModelBase)skill;
        if (current.GetDis(target) <= skill.skillPro.AttackRange)
        {
            return true;
        }
        return false;
    }

    //���ܵ�����Ŀ��
    public static List<ModelBase> GetTarget(this ISkill skill)
    {
        //0:�����ָ���Ŀ��ΪĿ��
        //1���ڹ�����Χ�ڵ�����Ŀ��
        //2:�ڹ�����Χ�ڵ�Ӣ�۵�Ŀ��
        switch (skill.skillPro.Target)
        {
            case 0:
                return GetTarget_0(skill);
            case 1:
                return GetTarget_1(skill);
            case 2:
                return GetTarget_2(skill);
        }

        return null;
    }

    //0:�����ָ���Ŀ��ΪĿ��
    public static List<ModelBase> GetTarget_0(ISkill skill)
    {
        List<ModelBase> results = new List<ModelBase>();
        Collider2D col = Tools.ScreenPointToRay2D(Camera.main, Input.mousePosition);
        if (col != null)
        {
            ModelBase target = col.GetComponent<ModelBase>();
            if (target != null)
            {
                //���ܵ�Ŀ������ �� ����ָ���Ŀ������Ҫ�����ñ�һ��
                if (skill.skillPro.TargetType == target.Type)
                {
                    results.Add(target);
                }
            }
        }
        return results;
    }

    //1���ڹ�����Χ�ڵ�����Ŀ��
    public static List<ModelBase> GetTarget_1(ISkill skill)
    {
        List<ModelBase> results = new List<ModelBase>();
        for (int i = 0; i < GameApp.FightWorldManager.heros.Count; i++)
        {
            //�ҵ��ڼ��ܷ�Χ�ڵ�Ŀ��
            if (skill.IsModelInSkillArea(GameApp.FightWorldManager.heros[i]))
            {
                results.Add(GameApp.FightWorldManager.heros[i]);
            }
        }

        for (int i = 0; i < GameApp.FightWorldManager.enemys.Count; i++)
        {
            //�ҵ��ڼ��ܷ�Χ�ڵ�Ŀ��
            if (skill.IsModelInSkillArea(GameApp.FightWorldManager.enemys[i]))
            {
                results.Add(GameApp.FightWorldManager.enemys[i]);
            }
        }
        return results;
    }

    //2:�ڹ�����Χ�ڵ�Ӣ�۵�Ŀ��
    public static List<ModelBase> GetTarget_2(ISkill skill)
    {
        List<ModelBase> results = new List<ModelBase>();
        for (int i = 0; i < GameApp.FightWorldManager.heros.Count; i++)
        {
            //�ҵ��ڼ��ܷ�Χ�ڵ�Ŀ��
            if (skill.IsModelInSkillArea(GameApp.FightWorldManager.heros[i]))
            {
                results.Add(GameApp.FightWorldManager.heros[i]);
            }
        }
        return results;
    }
}