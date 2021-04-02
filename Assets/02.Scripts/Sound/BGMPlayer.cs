using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    /// <summary>
    /// 씬 시작 시 BGM 재생
    /// </summary>
    public class BGMPlayer : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("BGM")] AudioClip m_clip;

        #endregion

        #region 유니티 생명주기

        private void Start()
        {
            SoundManager.Instance.PlaySoundBGM(m_clip);
        }

        #endregion
    } 
}
