using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//管理所有游戏中的配置表
public class ConfigManager 
{
    private Dictionary<string, ConfigData> LoadList;//需要读取的配置表
    private Dictionary<string, ConfigData> configs;//已经加载完的配置表

    public ConfigManager()
    {
        LoadList = new Dictionary<string, ConfigData>();
        configs = new Dictionary<string, ConfigData>();
    }
    //注册需要加载的注册表
    public void Register(string file,ConfigData config)
    {
        LoadList[file] = config;
    }
    //加载所有配置表
    public void LoadAllConfigs()
    {
        foreach(var item in LoadList)
        {
            TextAsset textAsset = item.Value.LoadFile();
            item.Value.Load(textAsset.text);
            configs.Add(item.Value.fileName, item.Value);
        }
        LoadList.Clear();
    }

    public ConfigData GetConFigData(string file)
    {
        if (configs.ContainsKey(file))
        {
            return configs[file];
        }
        else
        {
            return null;
        }
    }
}
