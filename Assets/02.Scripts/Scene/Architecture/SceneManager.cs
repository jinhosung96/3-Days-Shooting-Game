using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    public enum SCENE_CHANGE_TYPE
    {
        Fade = 0
    }

    /// <summary>
    /// 씬 전환 관리 제어
    /// </summary>
    public class SceneManager : SceneObject<SceneManager>
    {
        #region 변수

        [SerializeField] GameObject[] m_type;

        #endregion

        #region 외부 API

        public void LoadScene(string _nextSceneName, SCENE_CHANGE_TYPE _changeType)
        {
            m_type[(int)_changeType].GetComponent<ISceneChangeType>().ChangeScene(_nextSceneName);
        }

        #endregion
    }

}