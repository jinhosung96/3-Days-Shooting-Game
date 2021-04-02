using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFloatingTextController : MonoBehaviour
{
    [SerializeField] GameObject m_damageFloatingTextGO;
    [SerializeField] Vector3 m_offset;

    DamageFloatingText m_damageFloatingText;

    // Start is called before the first frame update
    void Start()
    {
        InitDanageFloatingText();
    }

    public void ApplyDamageText(float _damage)
    {
        m_damageFloatingText.ApplyDamageText(_damage);
    }

    private void InitDanageFloatingText()
    {
        HeadUpDisplay dmgFT = CreateDamageFloatingText();
        AddHUD(dmgFT);
    }

    private void AddHUD(HeadUpDisplay dmgFT)
    {
        HUDController hudController = GetComponent<HUDController>();
        hudController.HeadUpDisplays.Add(dmgFT);
        hudController.SetCanvas(dmgFT);
    }

    private HeadUpDisplay CreateDamageFloatingText()
    {
        GameObject dmgFT = Instantiate(m_damageFloatingTextGO);
        HeadUpDisplay hud = new HeadUpDisplay();
        hud.HUD = dmgFT.transform;
        hud.Offset = m_offset;

        m_damageFloatingText = dmgFT.GetComponent<DamageFloatingText>();

        return hud;
    }
}
