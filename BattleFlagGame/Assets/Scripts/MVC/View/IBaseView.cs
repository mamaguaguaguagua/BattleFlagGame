using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//��ͼ�ӿڣ���ͼҪ�̳�MonoBehaviour
public interface  IBaseView 
{
    #region ״̬��ѯ����
    bool IsInit();//��ͼ�Ƿ��ʼ��
    bool IsShow();//�Ƿ���ʾ
    #endregion
    #region �������ڹ���
    void InitUI();//��ʼ���
    void InitData();//��ʼ������
    void Open(params object[] args);//����壬�䳤����
    void Close(params object[] args);//�ر����
    void DestoryView();//ɾ�����
    #endregion

    void ApplyFunc(string eventName, params object[] args);//������ģ���¼�
    void ApplyControllerFunc(int controllerKey, string eventName, params object[] args);//��������������ģ���¼�
    void SetVisible(bool value);//��������
    int ViewId { get; set; }//���Id

    BaseController Controller { get; set; }//�������������


}
