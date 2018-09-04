using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IAudioService
{
    bool isPlayingMusic();

    //播放音乐
    void PlayMusic(AudioClip clip);

    //播放特效音
    void PlaySound(AudioClip clip,bool isLoop);
}