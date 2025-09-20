using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager 
{
    private AudioSource bgmSource;
    private Dictionary<string, AudioClip> clips;//��Ƶ�����ֵ�
    public SoundManager()//��ʼ������
    {
        clips = new Dictionary<string, AudioClip>();
        bgmSource = GameObject.Find("game").GetComponent<AudioSource>();
    }
    //���ű�������
    public void PlayBGM(string res)
    {
        //û�е�ǰҪ���ŵ����ֵ����
        if(clips.ContainsKey(res) == false)
        {
            //������Ƶ
            AudioClip clip = Resources.Load<AudioClip>($"Sounds/{res}");
            clips.Add(res, clip);
        }
        bgmSource.clip = clips[res];
        bgmSource.Play();//����
    }
}
