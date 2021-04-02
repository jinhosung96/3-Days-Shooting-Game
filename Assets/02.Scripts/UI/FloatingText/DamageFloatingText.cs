using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFloatingText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    public void ApplyDamageText(float _damage)
    {
        transform.localScale = Vector3.one;
        GetComponent<Text>().text = Mathf.RoundToInt(_damage).ToString();
        transform.DOScale(Vector3.zero, 0.2f).Restart();
    }
}
