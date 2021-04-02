using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    /// <summary>
    /// 스테이트 머신에서 작동하는 각각의 상태를 정의
    /// </summary>
    [RequireComponent(typeof(StateMachine))]
    public abstract class State : MonoBehaviour
    {
        #region 변수

        protected StateMachine m_machine;

        #endregion

        #region 유니티 생명 주기

        protected void Awake()
        {
            m_machine = GetComponent<StateMachine>();
            OnAwake();
        }

        protected void FixedUpdate()
        {
            if (m_machine.m_currentState != this) return;
            OnFixedUpdate();
        }

        // Update is called once per frame
        protected void Update()
        {
            if (m_machine.m_currentState != this) return;
            OnUpdate();
        }

        #endregion

        #region 가상 함수

        // 가상 함수, 자식에서 오버라이드해서 사용
        protected virtual void OnAwake() { } // 초기화용

        public virtual void OnEnter() { } // 해당 상태로 진입했을 때

        protected virtual void OnFixedUpdate() { } // 물리 작용 원할 때 매 프레임당

        protected virtual void OnUpdate() { } // 매 프레임 당

        public virtual void OnExit() { } // 상태가 끝날 때

        public virtual void OnReset() { } // 체크를 했을 때 데이터 리셋용

        #endregion
    } 
}
