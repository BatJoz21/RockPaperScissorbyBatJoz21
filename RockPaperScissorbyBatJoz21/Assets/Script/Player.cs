using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] Character selectedCharacter;
    [SerializeField] List<Character> characterList;
    [SerializeField] Transform atkPosition;

    public Character SelectedCharacter { get => selectedCharacter; }
    public List<Character> CharacterList { get => characterList; }

    void Start()
    {
        
    }

    public void Prepare()
    {
        selectedCharacter = null;
    }

    public void SelectCharacter(Character character)
    {
        selectedCharacter = character;
    }

    public void SetPlay(bool v)
    {
        foreach (var character in characterList)
        {
            character.Button.interactable = v;
        }
    }

    Vector3 direction = Vector3.zero;
    public void Attack()
    {
        selectedCharacter.transform
            .DOMove(atkPosition.position, 0.5f)
            .SetEase(Ease.Linear);
    }

    public bool IsAttacking()
    {
        if (selectedCharacter == null)
            return false;
        return DOTween.IsTweening(selectedCharacter.transform, true);
    }

    public void TakeDamage(int dmg)
    {
        selectedCharacter.ChangeHP(dmg);
        var sprite = selectedCharacter.GetComponent<SpriteRenderer>();
        sprite.DOColor(Color.red, 0.1f).SetLoops(4, LoopType.Yoyo);
    }

    public bool IsDamaging()
    {
        if (selectedCharacter == null)
            return false;
        var sprite = selectedCharacter.GetComponent<SpriteRenderer>();
        return DOTween.IsTweening(sprite);
    }

    public void Remove(Character character)
    {
        if (characterList.Contains(character) == false)
        {
            return;
        }

        if (selectedCharacter == character)
        {
            selectedCharacter = null;
        }
        character.Button.interactable = false;
        character.gameObject.SetActive(false);
        characterList.Remove(character);
    }

    public void Return()
    {
        selectedCharacter.transform
            .DOMove(selectedCharacter.InitialPosition, 0.5f)
            .SetEase(Ease.Linear);
    }

    public bool IsReturning()
    {
        if (selectedCharacter == null)
            return false;

        return DOTween.IsTweening(selectedCharacter.transform);
    }
}
