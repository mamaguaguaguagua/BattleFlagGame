using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ѡ��
public class OptionData
{
    public int Id;
    public string EventName;
    public string Name;
}

/// <summary>
/// ս���õ�����
/// </summary>
public class FightModel : BaseModel
{
    public List<OptionData> options;
    public ConfigData optionConfig;

    public FightModel(BaseController ctl) : base(ctl)
    {
        options = new List<OptionData>();
    }

    public override void Init()
    {
        optionConfig = GameApp.ConfigManager.GetConFigData("option");
        foreach (var item in optionConfig.GetLines())
        {
            OptionData opData = new OptionData();
            opData.Id = int.Parse(item.Value["Id"]);
            opData.Name = item.Value["Name"];
            opData.EventName = item.Value["EventName"];
            options.Add(opData);
        }
    }
}
