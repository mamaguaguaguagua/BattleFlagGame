using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Ӣ�۽ű�
/// </summary>
public class Hero : ModelBase,ISkill
{
    public SkillProperty skillPro { get; set; }
    public Slider hpSlider;//Ѫ��
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
    //ѡ��
    protected override void OnSelectCallBack(object arg)
    {
        //��һغ� ����ѡ�н�ɫ
        if (GameApp.FightWorldManager.state == GameState.Player)
        {   //���ܲ���
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
                //��ʾ·��
                GameApp.MapManager.ShowStepGrid(this, Step);
                GameApp.CommandManager.AddCommand(new ShowPathCommand(this));
                //���ѡ���¼�
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
    //����
    private void onAttackCallBack(System.Object arg)
    {
        Debug.Log("attack");
        GameApp.CommandManager.AddCommand(new ShowSkillAreaCommand(this));
    }

    //����
    private void onIdleCallBack(System.Object arg)
    {
        IsStop = true;
    }

    //ȡ�� �ƶ�
    private void onCanCelCallBack(System.Object arg)
    {
        GameApp.CommandManager.UnDo();
    }


    //δѡ��
    protected override void OnUnSelectCallBack(object arg)
    {
        base.OnUnSelectCallBack(arg);
        GameApp.ViewManager.Close((int)ViewType.HeroDesView);
    }
    //��ʾ��������
    public void ShowSkillArea()
    {
        GameApp.MapManager.ShowAttackStep(this, skillPro.AttackRange, Color.red);
    }

    public void HideSkillArea()
    {
        GameApp.MapManager.HideAttackStep(this, skillPro.AttackRange);
    }
    //���� 
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
            //Ӣ������Ҫ�Ƴ�
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
