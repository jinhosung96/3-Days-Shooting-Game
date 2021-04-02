using Doozy.Engine.UI;
using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    /// <summary>
    /// 페이드 인아웃 씬 전환 기능 정의
    /// </summary>
    public class FadeInOut : MonoBehaviour, ISceneChangeType
    {
        #region 외부 API

        public void ChangeScene(string _nextSceneName)
        {
            if (UICanvas.GetUICanvas("FadeCanvas") == null)
            {
                var fadeCanvas = UICanvas.CreateUICanvas("FadeCanvas");
                DontDestroyOnLoad(fadeCanvas);
                fadeCanvas.GetComponent<Canvas>().sortingOrder = 20000;
            }
            UIPopup fade = UIPopup.GetPopup("Fade");
            fade.GetComponent<FadeOverlay>().Show(_nextSceneName);
        }

        #endregion
    }
}