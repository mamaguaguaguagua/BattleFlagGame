using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 英雄脚本
/// </summary>
public class Hero : ModelBase,ISkill
{
    public SkillProperty skillPro { get; set; }
    public Slider hpSlider;//血条
    protected override void Start()
    {
        base.Start();

        hpSlider = transform.Find("hp/bg").GetComponent<Slider>();

    }
    public void Init(Dictionary<string, string> data, int row, int col)
    {
        this.data = data;
        this.RowIndex = row;
        this.ColIndex = col;
        Id = int.Parse(this.data["Id"]);
        Type = int.Parse(this.data["Type"]);
        Attack = int.Parse(this.data["Attack"]);
        Step = int.Parse(this.data["Step"]);
        MaxHp = int.Parse(this.data["Hp"]);
        CurHp = MaxHp;
        skillPro = new SkillProperty(int.Parse(this.data["Skill"]));
    }
    //选中
    protected override void OnSelectCallBack(object arg)
    {
        //玩家回合 才能选中角色
        if (GameApp.FightWorldManager.state == GameState.Player)
        {   //不能操作
            if (IsStop == true)
            {
                return;
            }
            if (GameApp.CommandManager.IsRunningCommand == true)
            {
                return;
            }
            GameApp.MsgCenter.PostEvent(Defines.OnUnSelectEvent);
            if (IsStop == false)
            {
                //显示路径
                GameApp.MapManager.ShowStepGrid(this, Step);
                GameApp.CommandManager.AddCommand(new ShowPathCommand(this));
                //添加选项事件
                addOptionEvents();
            }

            GameApp.ViewManager.Open(ViewType.HeroDesView, this);
        }
    }
    private void addOptionEvents()
    {
        GameApp.MsgCenter.AddTempEvent(Defines.OnAttackEvent, onAttackCallBack);
        GameApp.MsgCenter.AddTempEvent(Defines.OnIdleEvent, onIdleCallBack);
        GameApp.MsgCenter.AddTempEvent(Defines.OnCancelEvent, onCanCelCallBack);
    }
    //攻击
    private void onAttackCallBack(System.Object arg)
    {
        Debug.Log("attack");
        GameApp.CommandManager.AddCommand(new ShowSkillAreaCommand(this));
    }

    //待机
    private void onIdleCallBack(System.Object arg)
    {
        IsStop = true;
    }

    //取消 移动
    private void onCanCelCallBack(System.Object arg)
    {
        GameApp.CommandManager.UnDo();
    }


    //未选中
    protected override void OnUnSelectCallBack(object arg)
    {
        base.OnUnSelectCallBack(arg);
        GameApp.ViewManager.Close((int)ViewType.HeroDesView);
    }
    //显示技能区域
    public void ShowSkillArea()
    {
        GameApp.MapManager.ShowAttackStep(this, skillPro.AttackRange, Color.red);
    }

    public void HideSkillArea()
    {
        GameApp.MapManager.HideAttackStep(this, skillPro.AttackRange);
    }
    //死亡 
    public override void GetHit(ISkill skill)
    {
        GameApp.SoundManager.PlayEffect("hit", transform.position);
        CurHp -= skill.skillPro.Attack;
        GameApp.ViewManager.ShowHitNum($"-{skill.skillPro.Attack}", Color.red, transform.position);
        PlayEffect(skill.skillPro.AttackEffect);
        if (CurHp <= 0)
        {
            CurHp = 0;
            PlayAni("die");
            Destroy(gameObject, 1.2f);
            //英雄死了要移除
            GameApp.FightWorldManager.RemoveHero(this);
        }

        StopAllCoroutines();
        StartCoroutine(ChangeColor());
        StartCoroutine(UpdateHpSlider());
    }

    private IEnumerator ChangeColor()
    {
        bodySp.material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(0.25f);
        bodySp.material.SetFloat("_FlashAmount", 0);
    }

    private IEnumerator UpdateHpSlider()
    {
        hpSlider.gameObject.SetActive(true);
        hpSlider.DOValue((float)CurHp / (float)MaxHp, 0.25f);
        yield return new WaitForSeconds(0.75f);
        hpSlider.gameObject.SetActive(false);
    }
}
