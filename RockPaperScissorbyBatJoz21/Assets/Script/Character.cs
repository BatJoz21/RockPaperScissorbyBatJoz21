using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] CharacterType playerType;
    [SerializeField] int currentHp;
    [SerializeField] int maxHp;
    [SerializeField] int attackPower;
    [SerializeField] int defend;
    [SerializeField] TMP_Text overHeadText;
    [SerializeField] Image avatar;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text typeText;
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text hpText;
    [SerializeField] Button button;

    public Button Button { get => button; }
    public CharacterType PlayerType { get => playerType; }
    public int AttackPower { get => attackPower; }
    public int CurrentHp { get => currentHp; }

    void Start()
    {
        overHeadText.text = playerName;
        nameText.text = playerName;
        typeText.text = playerType.ToString();
        UpdateHPGUI();
        button.interactable = false;
    }

    public void ChangeHP(int amount)
    {
        currentHp += -(amount - defend);
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        UpdateHPGUI();
    }

    private void UpdateHPGUI()
    {
        healthBar.fillAmount = (float)currentHp / (float)maxHp;
        hpText.text = currentHp + "/" + maxHp;
    }
}
