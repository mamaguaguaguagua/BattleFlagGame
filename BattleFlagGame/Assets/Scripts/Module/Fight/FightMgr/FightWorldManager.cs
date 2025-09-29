using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Idle,
    Enter,
    Player,
    Enemy,
    GameOver
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
            case GameState.Player:
                _current = new FightPlayerUnit();
                break;
            case GameState.Enemy:
                _current = new FightEnemyUnit();
                break;
            case GameState.GameOver:
                _current = new FightGameOverUnit();
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
            Enemy enemy = objs[i].GetComponent<Enemy>();
            //��ǰλ�ñ�ռ�У�Ҫ�Ѷ�Ӧ�ķ����������ó��ϰ���
            GameApp.MapManager.ChangeBlockType(enemy.RowIndex, enemy.ColIndex, BlockType.Obstacle);
            enemys.Add(enemy);
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
    //�Ƴ�����
    public void RemoveEnemy(Enemy enemy)
    {
        enemys.Remove(enemy);

        //������Ҫռ�ø���
        GameApp.MapManager.ChangeBlockType(enemy.RowIndex, enemy.ColIndex, BlockType.Null);
        //������Ϸ�������ж�
        if (enemys.Count == 0)
        {
            ChangeState(GameState.GameOver);
        }
    }

    //�Ƴ�Ӣ��
    public void RemoveHero(Hero hero)
    {
        heros.Remove(hero);
        GameApp.MapManager.ChangeBlockType(hero.RowIndex, hero.ColIndex, BlockType.Null);
        //������Ϸ�������ж�
        if (heros.Count == 0)
        {
            ChangeState(GameState.GameOver);
        }
    }
    //����Ӣ���ж�
    public void ResetHeros()
    {
        for (int i = 0; i < heros.Count; i++)
        {
            heros[i].IsStop = false;
        }
    }

    //���õ����ж�
    public void ResetEnemys()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].IsStop = false;
        }
    }
    //������Ӣ�۵ľ���
    public ModelBase GetMinDisHero(ModelBase model)
    {
        if (heros.Count == 0)
        {
            return null;
        }

        Hero hero = heros[0];
        float min_dis = hero.GetDis(model);
        for (int i = 1; i < heros.Count; i++)
        {
            float dis = heros[i].GetDis(model);
            if (dis < min_dis)
            {
                min_dis = dis;
                hero = heros[i];
            }
        }
        return hero;
    }
    //ж����Դ
    public void ReLoadRes()
    {
        heros.Clear();
        enemys.Clear();
        GameApp.MapManager.Clear();
    }
}