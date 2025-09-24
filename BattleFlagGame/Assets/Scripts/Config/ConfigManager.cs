using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//����������Ϸ�е����ñ�
public class ConfigManager 
{
    private Dictionary<string, ConfigData> LoadList;//��Ҫ��ȡ�����ñ�
    private Dictionary<string, ConfigData> configs;//�Ѿ�����������ñ�

    public ConfigManager()
    {
        LoadList = new Dictionary<string, ConfigData>();
        configs = new Dictionary<string, ConfigData>();
    }
    //ע����Ҫ���ص�ע���
    public void Register(string file,ConfigData config)
    {
        LoadList[file] = config;
    }
    //�����������ñ�
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
