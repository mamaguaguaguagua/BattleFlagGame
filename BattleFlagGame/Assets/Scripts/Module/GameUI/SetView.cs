using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�����������
public class SetView : BaseView
{
    protected override void OnAwake()
    {
        base.OnAwake();
        Find<Button>("bg/closeBtn").onClick.AddListener(onCloseBtn);
        Find<Toggle>("bg/IsOpnSound").onValueChanged.AddListener(OnIsStopBtn);
        Find<Slider>("bg/soundCount").onValueChanged.AddListener(OnSliderBgmBtn);
        Find<Slider>("bg/effectCount").onValueChanged.AddListener(OnSliderEffectBtn);

        Find<Toggle>("bg/IsOpnSound").isOn = GameApp.SoundManager.IsStop;
        Find<Slider>("bg/soundCount").value = GameApp.SoundManager.BgmVolume;
        Find<Slider>("bg/effectCount").value = GameApp.SoundManager.EffectVolume;


    }
    //�Ƿ���
    private void OnIsStopBtn(bool isStop)
    {
        GameApp.SoundManager.IsStop = isStop;
    }
    //����Bgm����
    private void OnSliderBgmBtn(float value)
    {
        GameApp.SoundManager.BgmVolume = value;
    }
    //����effect����
    private void OnSliderEffectBtn(float value)
    {
        GameApp.SoundManager.EffectVolume  = value;
    }
    //�رհ�ť
    private void onCloseBtn()
    {
        GameApp.ViewManager.Close(ViewId);//�ر��Լ�
    }
}
