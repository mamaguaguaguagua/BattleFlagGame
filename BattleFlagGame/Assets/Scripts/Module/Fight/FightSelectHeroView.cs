using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ѡ��Ӣ�����
/// </summary>
public class FightSelectHeroView : BaseView
{
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
