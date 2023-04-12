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
    [SerializeField] private bool isAttackDone;
    [SerializeField] private bool isDamagingDone;
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
                    player1.Attack();
                    player2.Attack();
                    state = battleState.Attacking;
                }
                break;
            case battleState.Attacking:
                if(player1.IsAttacking() == false && player2.IsAttacking() == false)
                {
                    //calculate who took damage
                    //start damage anim
                    state = battleState.Damaging;
                }
                break;
            case battleState.Damaging:
                if(isDamagingDone)
                {
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
}
