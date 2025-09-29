using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager 
{
    private AudioSource bgmSource;
    private Dictionary<string, AudioClip> clips;//音频缓存字典

    private bool isStop;//是否静音
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
    private float bgmVolume;//bgm音量大小
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
    private float effectVolume;//音效音量大小
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
    public SoundManager()//初始化对象
    {
        clips = new Dictionary<string, AudioClip>();
        bgmSource = GameObject.Find("game").GetComponent<AudioSource>();
        isStop = false;
        BgmVolume = 1;
        effectVolume = 1;
    }
    //播放背景音乐
    public void PlayBGM(string res)
    {
        if (isStop == true) return;
        //没有当前要播放的音乐的情况
        if(clips.ContainsKey(res) == false)
        {
            //加载音频
            AudioClip clip = Resources.Load<AudioClip>($"Sounds/{res}");
            clips.Add(res, clip);
        }
        bgmSource.clip = clips[res];
        bgmSource.Play();//播放
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
