using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ѡ��Ӣ�����
/// </summary>
public class FightSelectHeroView : BaseView
{
    protected override void OnAwake()
    {
        base.OnAwake();
        Find<Button>("bottom/startBtn").onClick.AddListener(onFightBtn);
    }

    //ѡ��Ӣ�ۿ�ʼ���뵽��һغ�
    private void onFightBtn()
    {
        //���һ��Ӣ�۶�ûѡ��Ҫ��ʾ��� ѡ�� ������û�ж�Ӧ����ʾ���棬�Լ�����������չ
        if (GameApp.FightWorldManager.heros.Count == 0)
        {
            Debug.Log("û��ѡ��Ӣ��");
        }
        else
        {
            GameApp.ViewManager.Close(ViewId);//�رյ�ǰѡӢ�۽���

            //�л�����һغ�
            GameApp.FightWorldManager.ChangeState(GameState.Player);
        }
    }
    public override void Open(params object[] args)
    {
        base.Open(args);

        GameObject prefabObj = Find("bottom/grid/item");

        Transform gridTf = Find("bottom/grid").transform;

        for (int i = 0; i < GameApp.GameDataManager.heros.Count; i++)
        {
            Dictionary<string, string> data = GameApp.ConfigManager.GetConFigData("player").GetDataById(GameApp.GameDataManager.heros[i]);

            GameObject obj = Object.Instantiate(prefabObj, gridTf);

            obj.SetActive(true);

            HeroItem item = obj.AddComponent<HeroItem>();
            item.Init(data);
        }
    }
}
