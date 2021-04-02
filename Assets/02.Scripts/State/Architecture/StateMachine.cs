using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    /// <summary>
    /// 스테이트 머신
    /// </summary>
    public class StateMachine : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("초기 상태")] State m_aiState;
        public State m_currentState { get; private set; }
        State m_prevState;

        #endregion

        #region 유니티 생명주기

        private void Start()
        {
            SetState(m_aiState);
        }

        #endregion

        #region 외부 API

        public void SetState(State _nextState, bool isReset = true)
        {
            //Debug.Log($"{m_currentState} -> {_nextState}");
            m_prevState = m_currentState; // 현재 상태를 이전 상태로
            m_prevState?.OnExit(); // 이전 상태 종료
            if (isReset) m_prevState?.OnReset(); // 이전 상태 리셋
            m_currentState = _nextState; // 현재 상태를 다음 상태로
            m_currentState?.OnEnter(); // 현재 상태 시작
        }

        public void PrevState()
        {
            //Debug.Log($"{m_currentState} -> {m_prevState}");
            State temp = m_prevState;
            m_prevState = m_currentState;
            m_currentState?.OnExit();
            m_currentState = temp;
            m_currentState?.OnEnter();
        }

        #endregion

        #region 디버깅

        [ContextMenu("자세한 정보")]
        public void DebugProperty()
        {
            Debug.Log($"m_prevState : {m_prevState}");
            Debug.Log($"m_currentState : {m_currentState}");
        }

        #endregion
    } 
}
