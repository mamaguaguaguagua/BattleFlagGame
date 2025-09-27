using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Idle,
    Enter
}

/// <summary>
/// ս��������������ս����ص�ʵ�壨���� Ӣ�� ��ͼ ���� �ȣ�
/// </summary>
public class FightWorldManager
{
    public GameState state = GameState.Idle;

    private FightUnitBase current; //��ǰ������ս����Ԫ
    public List<Hero> heros;//ս���е�Ӣ�ۼ���
    public List<Enemy> enemys;//ս���е��˵ļ���
    public int RoundCount;//�غ���

    public FightUnitBase Current
    {
        get
        {
            return current;
        }
    }

    public FightWorldManager()
    {
        heros = new List<Hero>();
        enemys = new List<Enemy>();
        ChangeState(GameState.Idle);
    }

    public void Update(float dt)
    {
        if (current != null && current.Update(dt) == true)
        {
            //todo
        }
        else
        {
            current = null;
        }
    }

    //�л�ս��״̬

    public void ChangeState(GameState state)
    {
        FightUnitBase _current = current;
        this.state = state;
        switch (this.state)
        {
            case GameState.Idle:
                _current = new FightIdle();
                break;
            case GameState.Enter:
                _current = new FightEnter();
                break;
        }
        _current.Init();
    }
    //����ս�� ��ʼ�� һЩ��Ϣ ������Ϣ �غ���Ŀ��
    public void EnterFight()
    {
        RoundCount = 1;
        heros = new List<Hero>();
        enemys = new List<Enemy>();
        //�������еĵ��˽ű����д洢
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");//���������Enemy��ǩ
        Debug.Log("enemy:" + objs.Length);
        for (int i = 0; i < objs.Length; i++)
        {
            enemys.Add(objs[i].GetComponent<Enemy>());
        }
    }
    //���Ӣ��
    public void AddHero(Block b, Dictionary<string, string> data)
    {
        GameObject obj = Object.Instantiate(Resources.Load($"Model/{data["Model"]}")) as GameObject;
        obj.transform.position = new Vector3(b.transform.position.x, b.transform.position.y, -1);
        Hero hero = obj.AddComponent<Hero>();
        hero.Init(data, b.RowIndex, b.ColIndex);
        //��λ�ñ�ռ���ˣ����÷��������Ϊ�ϰ���
        b.Type = BlockType.Obstacle;
        heros.Add(hero);
    }
}