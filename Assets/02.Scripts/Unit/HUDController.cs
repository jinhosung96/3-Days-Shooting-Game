using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Doozy.Engine.UI;

namespace JHS
{
    [Serializable]
    public class HeadUpDisplay
    {
        [SerializeField, LabelName("HUD")] Transform m_hud;
        public Transform HUD { get => m_hud; set => m_hud = value; }

        [SerializeField, LabelName("오프셋 Y")] Vector3 m_offset;
        public Vector3 Offset { get => m_offset; set => m_offset = value; }
    }

    /// <summary>
    /// HUD가 플레이어의 머리 위에 위치하도록 제어하는 객체
    /// </summary>
    public class HUDController : MonoBehaviour
    {
        #region 변수

        [SerializeField, ArrayElementLabelName("m_hud")] List<HeadUpDisplay> m_headUpDisplays;

        public List<HeadUpDisplay> HeadUpDisplays { get => m_headUpDisplays; }

        #endregion

        #region 유니티 생명주기

        void Awake()
        {            
            for (int i = 0; i < HeadUpDisplays.Count; i++)
            {
                SetCanvas(HeadUpDisplays[i]);
            }
        }

        public void SetCanvas(HeadUpDisplay _hud)
        {
            UICanvas canvas_HUD = UICanvas.GetUICanvas("HUDCanvas", true);
            _hud.HUD.SetParent(canvas_HUD.transform);
        }

        void LateUpdate()
        {
            for (int i = 0; i < HeadUpDisplays.Count; i++)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + HeadUpDisplays[i].Offset);
                HeadUpDisplays[i].HUD.position = screenPos;
            }
        }

        #endregion
    } 
}
