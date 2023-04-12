using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private battleState state;
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;


    //Temporary
    [SerializeField] private bool isPlayer1DoneSelect;
    [SerializeField] private bool isPlayer2DoneSelect;
    [SerializeField] private bool isReturningDone;
    [SerializeField] private bool isPlayerEliminated;

    enum battleState
    {
        Preparation,
        Player1Select,
        Player2Select,
        Attacking,
        Damaging,
        Returning,
        BattleOver
    }

    void Start()
    {
        
    }

    void Update()
    {
        switch (state)
        {
            case battleState.Preparation:
                player1.Prepare();
                player2.Prepare();

                player1.SetPlay(true);
                player2.SetPlay(false);
                state = battleState.Player1Select;
                break;

            case battleState.Player1Select:
                if (player1.SelectedCharacter != null)
                {
                    player1.SetPlay(false);
                    player2.SetPlay(true);
                    state = battleState.Player2Select;
                }
                break;

            case battleState.Player2Select:
                if(player2.SelectedCharacter != null)
                {
                    player2.SetPlay(false);
                    player1.Attack();
                    player2.Attack();
                    state = battleState.Attacking;
                }
                break;

            case battleState.Attacking:
                if(player1.IsAttacking() == false && player2.IsAttacking() == false)
                {
                    CalculateBattle(player1, player2, out Player winner, out Player loser);
                    if (winner == null)
                    {
                        player1.TakeDamage(player2.SelectedCharacter.AttackPower);
                        player2.TakeDamage(player1.SelectedCharacter.AttackPower);
                    }
                    else
                    {
                        loser.TakeDamage(winner.SelectedCharacter.AttackPower);
                    }

                    if (player1.SelectedCharacter.CurrentHp == 0)
                    {
                        player1.Remove(player1.SelectedCharacter);
                    }
                    if (player2.SelectedCharacter.CurrentHp == 0)
                    {
                        player2.Remove(player2.SelectedCharacter);
                    }

                    state = battleState.Damaging;
                }
                break;

            case battleState.Damaging:
                if(player1.IsDamaging() == false && player2.IsDamaging() == false)
                {
                    // animasi return
                    state = battleState.Returning;
                }
                break;

            case battleState.Returning:
                if(isReturningDone)
                {
                    if(isPlayerEliminated)
                    {
                        state = battleState.BattleOver;
                    }
                    else
                    {
                        state = battleState.Preparation;
                    }
                }
                break;

            case battleState.BattleOver:
                break;
        }
    }

    private void CalculateBattle(Player player1, Player player2, out Player winner, out Player loser)
    {
        var type1 = player1.SelectedCharacter.PlayerType;
        var type2 = player2.SelectedCharacter.PlayerType;

        if (type1 == CharacterType.Rock && type2 == CharacterType.Paper)
        {
            winner = player2;
            loser = player1;
        }
        else if (type1 == CharacterType.Rock && type2 == CharacterType.Scissor)
        {
            winner = player1;
            loser = player2;
        }
        else if (type1 == CharacterType.Paper && type2 == CharacterType.Rock)
        {
            winner = player1;
            loser = player2;
        }
        else if (type1 == CharacterType.Paper && type2 == CharacterType.Scissor)
        {
            winner = player2;
            loser = player1;
        }
        else if (type1 == CharacterType.Scissor && type2 == CharacterType.Paper)
        {
            winner = player1;
            loser = player2;
        }
        else if (type1 == CharacterType.Scissor && type2 == CharacterType.Rock)
        {
            winner = player2;
            loser = player1;
        }
        else
        {
            winner = null;
            loser = null;
        }
    }
}
