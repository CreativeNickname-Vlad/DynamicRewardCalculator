using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardCalculator : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] PlayerStats playerStats;
    [SerializeField] EnemyStats enemyStats;

    [Header("Reward Points")]
    public int _rewardPointMin          = 5;
    public int _rewardPointStMin        = 10;
    public int _rewardPointMed          = 15;
    public int _rewardPointStMax        = 20;
    public int _rewardPointMax          = 25;

    [Header("Reward Point Margin")]
    public int _noReward                = 35;
    public int _badReward               = 45;
    public int _okReward                = 65;
    public int _goodReward              = 85;
    



    /// <summary>
    ///  PlayerResourceChecker and PlayerLevelChecker use simal simplistic logic 
    ///  alocate poin rewards to the player
    /// </summary>
    public void PlayerResourceChecker()
    {
        switch (playerStats._resourcers)
        {
            case 0:
                playerStats._resourcerRewardPoint = _rewardPointMin;
                Debug.LogWarning("Reawrd for Resoucer is:" + " " + playerStats._resourcerRewardPoint);
                break;
            case 1:
                playerStats._resourcerRewardPoint = _rewardPointStMin;
                Debug.LogWarning("Reawrd for Resoucer is:" + " " + playerStats._resourcerRewardPoint);
                break;
            case 2:
                playerStats._resourcerRewardPoint = _rewardPointMed;
                Debug.LogWarning("Reawrd for Resoucer is:" + " " + playerStats._resourcerRewardPoint);
                break;
            case 3:
                playerStats._resourcerRewardPoint = _rewardPointStMax;
                Debug.LogWarning("Reawrd for Resoucer is:" + " " + playerStats._resourcerRewardPoint);
                break;
            case 4:
                playerStats._resourcerRewardPoint = _rewardPointMax;
                Debug.LogWarning("Reawrd for Resoucer is:" + " " + playerStats._resourcerRewardPoint);
                break;
        }


    }

    /// <summary>
    /// Timeer function got removed due to further complications and issues, as there would need to now be a certain margins for 
    /// max time in fight and min time in fight, which became quite difficult to manage
    /// </summary>

    public void PlayerLevelChecker()
    {
        if (playerStats._pLevel < 6)
        {
            playerStats._levelRewardPoint = _rewardPointMax;
            Debug.LogWarning("Reawrd for Level differance is:" + " " + playerStats._levelRewardPoint);
        }
        else if (playerStats._pLevel < 12)
        {
            playerStats._levelRewardPoint = _rewardPointStMax;
            Debug.LogWarning("Reawrd for Level differance is:" + " " + playerStats._levelRewardPoint);
        }
        else if (playerStats._pLevel < 18)
        {
            playerStats._levelRewardPoint = _rewardPointMed;
            Debug.LogWarning("Reawrd for Level differance is:" + " " + playerStats._levelRewardPoint);
        }
        else if (playerStats._pLevel < 24)
        {
            playerStats._levelRewardPoint = _rewardPointStMin;
            Debug.LogWarning("Reawrd for Level differance is:" + " " + playerStats._levelRewardPoint);
        }
        else if (playerStats._pLevel < 31)
        {
            playerStats._levelRewardPoint = _rewardPointMin;
            Debug.LogWarning("Reawrd for Level differance is:" + " " + playerStats._levelRewardPoint);
        }
    }

    public void ArmourDifChecker()
    {
        if (playerStats._armourSet > enemyStats._armourSet)
        {
            playerStats._armourRewardPoint = _rewardPointMin;

            Debug.LogWarning("Reawrd for Armour differance is:" + " " + playerStats._armourRewardPoint);
        }
        else if (playerStats._armourSet == enemyStats._armourSet)
        {
            playerStats._armourRewardPoint = _rewardPointMed;

            Debug.LogWarning("Reawrd for Armour differance is:" + " " + playerStats._armourRewardPoint);
        }
        else if (playerStats._armourSet < enemyStats._armourSet)
        {
            playerStats._armourRewardPoint = _rewardPointMax;

            Debug.LogWarning("Reawrd for Armour differance is:" + " " + playerStats._armourRewardPoint);
        }
    }

    /// <summary>
    /// As the weapon value for the enemy weapon had been removed it was removed with enemy type.
    /// This was done as the simulation needs to yeild a resoult no matter of the current 
    /// stats, therefore the enemys ability to attack was removed. But it can be simply added
    /// NOTE: Further refinment will be required on the statments as this is uses the ArmourDifChecker
    /// </summary>
    public void WeaponDifToTypeChecker()
    {
        if (playerStats._weapon > enemyStats._enemyType)
        {
            playerStats._wepToTypeRewardPoint = _rewardPointMin;
            Debug.LogWarning("Reawrd for Weapon to Enemy Type differance is:" + " " + playerStats._wepToTypeRewardPoint);
        }
        else if (playerStats._weapon == enemyStats._enemyType)
        {
            playerStats._wepToTypeRewardPoint = _rewardPointMed;
            Debug.LogWarning("Reawrd for Weapon to Enemy Type differance is:" + " " + playerStats._wepToTypeRewardPoint);
        }
        else if (playerStats._weapon < enemyStats._enemyType)
        {
            playerStats._wepToTypeRewardPoint = _rewardPointMax;
            Debug.LogWarning("Reawrd for Weapon to Enemy Type differance is:" + " " + playerStats._wepToTypeRewardPoint);
        }

    }

    public void CombinedRewardPoints()
    {
        playerStats._playerRewardPoints = playerStats._resourcerRewardPoint + playerStats._levelRewardPoint + 
            playerStats._armourRewardPoint + playerStats._wepToTypeRewardPoint;
        Debug.LogWarning("Combined Rewared points are:" + " " + playerStats._playerRewardPoints);
    }

}
