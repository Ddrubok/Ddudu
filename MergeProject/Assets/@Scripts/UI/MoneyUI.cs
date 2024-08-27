using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        Managers.Game.OnMoneyChanged -= HandleOnMoneyChanged;
        Managers.Game.OnMoneyChanged += HandleOnMoneyChanged;
    }
    void HandleOnMoneyChanged(int value)
    {
        textMeshProUGUI.text = value.ToString();
    }

    private void OnDestroy()
    {
        Managers.Game.OnMoneyChanged -= HandleOnMoneyChanged;
    }
}
