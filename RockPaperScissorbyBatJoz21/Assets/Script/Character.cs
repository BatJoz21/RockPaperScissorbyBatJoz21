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
    [SerializeField] int attack;
    [SerializeField] int defend;
    [SerializeField] TMP_Text overHeadText;
    [SerializeField] Image avatar;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text typeText;
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text hpText;
    [SerializeField] Button button;

    public Button Button { get => button; }

    void Start()
    {
        overHeadText.text = playerName;
        nameText.text = playerName;
        typeText.text = playerType.ToString();
        healthBar.fillAmount = (float) currentHp / (float) maxHp;
        hpText.text = currentHp + "/" + maxHp;
        button.interactable = false;
    }

    void Update()
    {

    }
}
