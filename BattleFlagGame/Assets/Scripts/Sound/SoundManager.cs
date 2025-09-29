using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager 
{
    private AudioSource bgmSource;
    private Dictionary<string, AudioClip> clips;//��Ƶ�����ֵ�

    private bool isStop;//�Ƿ���
    public  bool IsStop
    {
        get
        {
            return isStop;
        }
        set
        {
            isStop = value;
            if (isStop == true)
            {
                bgmSource.Pause();
            }
            else
            {
                bgmSource.Play();
            }
        }
    }
    private float bgmVolume;//bgm������С
    public float BgmVolume
    {
        get
        {
            return bgmVolume;
        }
        set
        {
            bgmVolume = value;
            bgmSource.volume = bgmVolume;
        }
    }
    private float effectVolume;//��Ч������С
    public float EffectVolume
    {
        get
        {
            return effectVolume;
        }
        set
        {
            effectVolume = value;
          
        }
    }
    public SoundManager()//��ʼ������
    {
        clips = new Dictionary<string, AudioClip>();
        bgmSource = GameObject.Find("game").GetComponent<AudioSource>();
        isStop = false;
        BgmVolume = 1;
        effectVolume = 1;
    }
    //���ű�������
    public void PlayBGM(string res)
    {
        if (isStop == true) return;
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
    public void PlayEffect(string name, Vector3 pos)
    {
        if (isStop == true)
        {
            return;
        }

        AudioClip clip = null;

        if (clips.ContainsKey(name) == false)
        {
            clip = Resources.Load<AudioClip>($"Sounds/{name}");
            clips.Add(name, clip);
        }
        AudioSource.PlayClipAtPoint(clips[name], pos);
    }
}
