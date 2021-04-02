using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IDeathBehaviour
{
    public void Death()
    {
        JHS.SceneManager.Instance.LoadScene("InGame", JHS.SCENE_CHANGE_TYPE.Fade);
    }
}
