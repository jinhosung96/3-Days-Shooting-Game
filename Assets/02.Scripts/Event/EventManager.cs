using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    // 유니티 상에 일어나는 이벤트 제어
    public class EventManager : SceneObject<EventManager>
    {
        #region 변수

        public delegate void Reaction();
        Dictionary<string, List<Reaction>> m_listeners = new Dictionary<string, List<Reaction>>();

        #endregion

        #region 외부 API

        /// <summary>
        /// 리스너 추가
        /// 리스너는 해당 이벤트가 일어났을 때 지정된 리액션을 실행한다.
        /// </summary>
        /// <param LabelName="_eventType">리액션을 일으킬 이벤트</param>
        /// <param LabelName="_reaction">이벤트가 일어났을 때 실행할 리액션</param>
        public void AddListener(string _eventType, Reaction _reaction)
        {
            if (!m_listeners.ContainsKey(_eventType))
            {
                List<Reaction> tempList = new List<Reaction>();
                m_listeners.Add(_eventType, tempList);
            }

            m_listeners[_eventType].Add(_reaction);
        }

        /// <summary>
        /// 지정된 이벤트가 발생했다고 리스너들에게 알림
        /// 
        /// Exception : 
        ///     1. 씬 전환 시 ClearListeners() 미 실행시 예외 발생
        /// </summary>
        /// <param LabelName="_eventType">전달할 이벤트</param>
        public void PostNofication(string _eventType)
        {
            if (!m_listeners.ContainsKey(_eventType)) return;

            for (int i = 0; i < m_listeners[_eventType].Count; i++)
            {
                m_listeners[_eventType][i]();
            }
        }

        /// <summary>
        /// 리스너 목록 초기화
        /// </summary>
        public void ClearListeners()
        {
            m_listeners.Clear();
        }

        #endregion
    } 
}
