using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    public class SoundManager : SceneObject<SoundManager>
    {
        #region 변수

        [SerializeField, LabelName("배경음 오디오 소스")] AudioSource m_audioSourceForBgm;
        [SerializeField, LabelName("효과음 오디오 소스")] AudioSource m_audioSourceForEffects;

        #endregion

        #region 외부 API

        public void PlaySoundBGM(AudioClip _clip)
        {
            m_audioSourceForBgm.clip = _clip;
            m_audioSourceForBgm.Play();
        }

        public void StopSoundBGM()
        {
            m_audioSourceForBgm.Stop();
        }

        public void PlaySoundEffect(AudioClip _clip)
        {
            m_audioSourceForEffects.PlayOneShot(_clip);
        }

        #endregion
    } 
}
