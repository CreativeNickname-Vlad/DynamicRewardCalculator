using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCalculation : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] PlayerStats playerStats;
    [SerializeField] EnemyStats enemyStats;
    [SerializeField] ButtonController buttonController;

    [Header("Player Calculated Stats")]
    public float _calADO;   // Player attack damage output
    public float _calDS;    // Player Defence stats
    public float _dmgDealt; // Player Damage dealt to enemy through armour

    [Header("Enemy Calculated Stats")]
    public float _calEDS;   // Enemy Defence stats
    public float _calEH;    // Enemy heatlth stats


    // Player Stat calculation
    public void PlayerArmourChecker()
    {
        // This function calculates both player strenght and defease as the armour set gives the same stats to both

        switch (playerStats._armourSet)
        {
            case 0:
                playerStats._strenghComb = playerStats._strenghtBase + playerStats._armSetB;
                playerStats._defenceComb = playerStats._defence + playerStats._armSetB;
                _calDS = playerStats._defenceComb;
                buttonController.StatTextUpdate();

                Debug.LogWarning("Combined Defance:" + " " + _calDS);
                Debug.LogWarning("Combined Strenght:" + " " + playerStats._strenghComb);

                Debug.LogWarning("Base Defance:" + " " + playerStats._defence);
                Debug.LogWarning("Base Strenght:" + " " + playerStats._strenghtBase);
                break;
            case 1:
                playerStats._strenghComb = playerStats._strenghtBase + playerStats._armSetA;
                playerStats._defenceComb = playerStats._defence + playerStats._armSetA;
                _calDS = playerStats._defenceComb;
                buttonController.StatTextUpdate();

                Debug.LogWarning("Combined Defance:" + " " + _calDS);
                Debug.LogWarning("Combined Strenght:" + " " + playerStats._strenghComb);

                Debug.LogWarning("Base Defance:" + " " + playerStats._defence);
                Debug.LogWarning("Base Strenght:" + " " + playerStats._strenghtBase);
                break;
            case 2:
                playerStats._strenghComb = playerStats._strenghtBase + playerStats._armSetH;
                playerStats._defenceComb = playerStats._defence + playerStats._armSetH;
                _calDS = playerStats._defenceComb;
                buttonController.StatTextUpdate();

                Debug.LogWarning("Combined Defance:" + " " + _calDS);
                Debug.LogWarning("Combined Strenght:" + " " + playerStats._strenghComb);

                Debug.LogWarning("Base Defance:" + " " + playerStats._defence);
                Debug.LogWarning("Base Strenght:" + " " + playerStats._strenghtBase);
                break;
        }
    }

    public void PlayerWeaponChecker()
    {
        switch (playerStats._weapon)
        {
            case 0:
                playerStats._atkDmgOut = playerStats._strenghComb * (playerStats._wepB);
                _calADO = playerStats._atkDmgOut;
                break;
            case 1:
                playerStats._atkDmgOut = playerStats._strenghComb * (playerStats._wepA);
                _calADO = playerStats._atkDmgOut;
                break;
            case 2:
                playerStats._atkDmgOut = playerStats._strenghComb * (playerStats._wepH);
                _calADO = playerStats._atkDmgOut;
                break;
        }
    }

    public void PlayerStaminaCheck()
    {
        switch (playerStats._stamina)
        {
            case 0:
                _calADO *= playerStats._stamWeak;
                break;
            case 1:
                _calADO *= playerStats._stamHalf;
                break;
            case 2:
                _calADO *= 1;
                break;
        }
    }

    // Enemy Stats calculation
    public void EnemyArmourChecker()
    {
        switch (enemyStats._armourSet)
        {
            case 0:
                enemyStats._defenceComb = enemyStats._defence + enemyStats._armSetB;
                _calEDS = enemyStats._defenceComb;
                buttonController.StatTextUpdate();

                Debug.LogError("Combined Enemy Defance:" + " " + _calEDS);
                Debug.LogError("Combined Enemy Strenght:" + " " + enemyStats._defenceComb);

                break;
            case 1:
                enemyStats._defenceComb = enemyStats._defence + enemyStats._armSetA;
                _calEDS = enemyStats._defenceComb;
                buttonController.StatTextUpdate();


                Debug.LogError("Combined Enemy Defance:" + " " + _calEDS);
                Debug.LogError("Combined Enemy Strenght:" + " " + enemyStats._defenceComb);
                break;
            case 2:
                enemyStats._defenceComb = enemyStats._defence + enemyStats._armSetH;
                _calEDS = enemyStats._defenceComb;
                buttonController.StatTextUpdate();

                Debug.LogError("Combined Enemy Defance:" + " " + _calEDS);
                Debug.LogError("Combined Enemy Strenght:" + " " + enemyStats._defenceComb);
                break;
        }
    }

    public void EnemyHealthChecker()
    {
        switch (enemyStats._enemyType)
        {
            case 0:
                enemyStats._healthComb = enemyStats._health * (enemyStats._typeB);
                _calEH = enemyStats._healthComb;
                buttonController.StatTextUpdate();

                Debug.LogError("Combined Enemy Health:" + " " + _calEH);

                break;
            case 1:
                enemyStats._healthComb = enemyStats._health * (enemyStats._typeA);
                _calEH = enemyStats._healthComb;
                buttonController.StatTextUpdate();

                Debug.LogError("Combined Enemy Health:" + " " + _calEH);
                break;
            case 2:
                enemyStats._healthComb = enemyStats._health * (enemyStats._typeH);
                _calEH = enemyStats._healthComb;
                buttonController.StatTextUpdate();

                Debug.LogError("Combined Enemy Health:" + " " + _calEH);
                break;
        }
    }

    // this needs to be called first
    public void EnemyCalculations()
    {
        EnemyArmourChecker();

        EnemyHealthChecker();
    }

    // Create a function that will be on hit on a button that will call the other 3 
    public void PlayerDamageCalculations()
    {
        PlayerArmourChecker();

        PlayerWeaponChecker();

        PlayerStaminaCheck();


        _dmgDealt = _calADO / (Mathf.Pow((_calEDS / _calADO), 2));

    }
    
    // Player & Enemy Anim Corutine Timer
    IEnumerator AnimTimer()
    {
        playerStats._pAnimator.SetBool("pAttackingBool", true);
        enemyStats._eAnimator.SetBool("eIsDead", true);
        yield return new WaitForSeconds(1.1f);
        playerStats._pAnimator.SetBool("pAttackingBool", false);
        yield return new WaitForSeconds(2.3f);
        enemyStats._eAnimator.SetBool("eIsDead", false);
    }
    public void PlayerAttackMove()
    {
        // Put player animation here 
        _calEH -= _dmgDealt;   // _dmgeDealth is the damage that the player would do through the actuall armour of the enemy.
        StartCoroutine(AnimTimer());
    }
}

