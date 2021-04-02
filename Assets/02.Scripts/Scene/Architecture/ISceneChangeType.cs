using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    /// <summary>
    /// 씬 전환 방법 제시
    /// </summary>
    public interface ISceneChangeType
    {
        void ChangeScene(string _nextSceneName);
    }
}