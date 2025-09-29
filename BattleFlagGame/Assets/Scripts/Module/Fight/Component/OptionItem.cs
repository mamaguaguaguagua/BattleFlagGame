using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ѡ��
/// </summary>
public class OptionItem : MonoBehaviour
{
    OptionData op_data;

    public void Init(OptionData data)
    {
        op_data = data;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate ()
        {
            GameApp.MsgCenter.PostTempEvent(op_data.EventName);//ִ�����ñ������õ�event�¼�
            GameApp.ViewManager.Close((int)ViewType.SelectOptionView);//�ر�ѡ�����
        });
        transform.Find("txt").GetComponent<Text>().text = op_data.Name;
    }
}
