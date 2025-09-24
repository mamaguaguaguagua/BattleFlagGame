using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 读取csv格式的数据表（逗号隔开的数据格式）
/// </summary>
public class ConfigData 
{
    private Dictionary<int, Dictionary<string, string>> datas;//每个数据表存储到数据字典当中 key是字典id,值是每一行存储的内容
    public string fileName;//配置表文件
    public ConfigData(string fileName)
    {
        this.fileName = fileName;
        this.datas = new Dictionary<int, Dictionary<string, string>>();
    }
    public TextAsset LoadFile()
    {
        return Resources.Load<TextAsset>($"Data/{fileName}");
    }
    public void Load(string txt)
    {
        string[] dataArr = txt.Split("\n");//换行
        string[] titleArr = dataArr[0].Trim().Split(',');//逗号切割
        //内容从第三行开始读取
        for(int i = 2; i < dataArr.Length; i++)
        {
            string[] tempArr=dataArr[i].Trim().Split(',');
            Dictionary<string, string> tempData = new Dictionary<string, string>();
            for(int j = 0; j < tempArr.Length; j++)
            {
                tempData.Add(titleArr[j], tempArr[j]);
            }
            datas.Add(int.Parse(tempData["Id"]), tempData);
        }
    }
    public Dictionary<string,string>GetDataById(int id)
    {
        if (datas.ContainsKey(id))
        {
            return datas[id];
        }
        return null;
    }

    public Dictionary<int, Dictionary<string, string>> GetLines()
    {
        return datas;
    }
}
