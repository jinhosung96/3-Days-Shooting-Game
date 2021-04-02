using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    /// <summary>
    /// 컨트롤러 시스템 제어
    /// </summary>
    public class ControllerSystem : SceneObject<ControllerSystem>
    {
        #region 변수

        [SerializeField, LabelName("조이스틱 컨트롤러")] JoystickController m_joystickController;
        [NonSerialized,  LabelName("외부 API 컨트롤러")] public GameObject m_interactionControllerGO;

        #endregion

        #region 속성

        /// <summary>
        /// 조이스틱 입력 방향
        /// </summary>
        public Vector3 InputDirection { get => m_joystickController.InputDirection; }

        #endregion
    } 
}
