using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ��Ϸ���ݹ��������洢��һ�������Ϸ��Ϣ��
/// </summary>
public class GameDataManager
{
    public List<int> heros;//��ѡӢ�ۼ���

    public int Money;//���
    public GameDataManager()
    {
        heros = new List<int>();

        //����play.txt�ı���Ĭ��Ԥ��ǰ����Ӣ�۵�id
        heros.Add(10001);
        heros.Add(10002);
        heros.Add(10003);

    }
}