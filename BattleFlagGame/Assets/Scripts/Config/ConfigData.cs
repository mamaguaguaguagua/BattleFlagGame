using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��ȡcsv��ʽ�����ݱ����Ÿ��������ݸ�ʽ��
/// </summary>
public class ConfigData 
{
    private Dictionary<int, Dictionary<string, string>> datas;//ÿ�����ݱ�洢�������ֵ䵱�� key���ֵ�id,ֵ��ÿһ�д洢������
    public string fileName;//���ñ��ļ�
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
        string[] dataArr = txt.Split("\n");//����
        string[] titleArr = dataArr[0].Trim().Split(',');//�����и�
        //���ݴӵ����п�ʼ��ȡ
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
