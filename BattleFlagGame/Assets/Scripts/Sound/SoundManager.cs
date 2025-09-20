using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager 
{
    private AudioSource bgmSource;
    private Dictionary<string, AudioClip> clips;//音频缓存字典
    public SoundManager()//初始化对象
    {
        clips = new Dictionary<string, AudioClip>();
        bgmSource = GameObject.Find("game").GetComponent<AudioSource>();
    }
    //播放背景音乐
    public void PlayBGM(string res)
    {
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
}
