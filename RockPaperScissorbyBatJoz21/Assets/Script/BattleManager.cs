using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private battleState state;

    [SerializeField] private bool isPlayer1DoneSelect;
    [SerializeField] private bool isPlayer2DoneSelect;
    [SerializeField] private bool isAttackDone;
    [SerializeField] private bool isDamagingDone;
    [SerializeField] private bool isReturningDone;
    [SerializeField] private bool isPlayerEliminated;

    //[SerializeField] Player player1;
    //[SerializeField] Player player2;

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
                // Player prepares
                // Set player 1 play 1st
                state = battleState.Player1Select;
                break;
            case battleState.Player1Select:
                if(isPlayer1DoneSelect)
                {
                    state = battleState.Player2Select;
                }
                break;
            case battleState.Player2Select:
                if(isPlayer2DoneSelect)
                {
                    state = battleState.Attacking;
                }
                break;
            case battleState.Attacking:
                if(isAttackDone)
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
