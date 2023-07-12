using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonController : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] PlayerStats        playerStats;
    [SerializeField] EnemyStats         enemyStats;
    [SerializeField] RewardCalculator   rewardCalculator;
    [SerializeField] StatCalculation    statCalculation;
    [SerializeField] ItemSpawner        itemSpawner;

    [Header("Plaer Stats Text")]
    [SerializeField] private TextMeshProUGUI _pHealth;

    [SerializeField] private TextMeshProUGUI _pDefence;
    [SerializeField] private TextMeshProUGUI _pStrenght;

    [SerializeField] private TextMeshProUGUI _pDefenceComb;
    [SerializeField] private TextMeshProUGUI _pStrenghtComb;

    [SerializeField] private TextMeshProUGUI _pLevel;

    [SerializeField] private TextMeshProUGUI _pDDTE; //Damage Dealt To Enemy
    [SerializeField] private TextMeshProUGUI _pRewardPoints;

    [Header("Enemy Stats Text")]
    [SerializeField] private TextMeshProUGUI _eHealth;
    [SerializeField] private TextMeshProUGUI _eDefence;
    [SerializeField] private TextMeshProUGUI _eDefenceComb;
    [SerializeField] private TextMeshProUGUI _eHealthComb;


    // Stats Increase & Decrease (Player)
    public void StatNumberIncrease()
    {
        playerStats._pLevel++;
        playerStats._health += playerStats._pLvUpIncrease;
        playerStats._defence += playerStats._pLvUpIncrease;
        playerStats._strenghtBase += playerStats._pLvUpIncrease;
    }

    public void StatNumberDecrease()
    {
        playerStats._pLevel--;
        playerStats._health -= playerStats._pLvUpIncrease;
        playerStats._defence -= playerStats._pLvUpIncrease;
        playerStats._strenghtBase -= playerStats._pLvUpIncrease;
    }

    // Update the Stat Number
    public void StatTextUpdate()
    {
       
        _pLevel.text = "Lv: " + playerStats._pLevel + "";
        _pHealth.text = playerStats._health + "";

        _pDefenceComb.text = playerStats._defenceComb + "";
        _pStrenghtComb.text = playerStats._strenghComb + "";

        _pDefence.text = playerStats._defence + "";
        _pStrenght.text = playerStats._strenghtBase + "";

        _pDDTE.text = statCalculation._calADO + "" ;
        _pRewardPoints.text = playerStats._playerRewardPoints + "";

        _eHealthComb.text = enemyStats._healthComb + "";
        _eDefenceComb.text = enemyStats._defenceComb + "";

        _eHealth.text = enemyStats._health + "";
        _eDefence.text = enemyStats._defence + "";

        
    }

    // Combined function of both Stat & Text Updates 
    public void PlayerLvUpStatIncrease()
    {
        
        StatNumberIncrease();
        StatTextUpdate();
    }
    public void PlayerLvDownStatIncrease()
    {
        StatNumberDecrease();
        StatTextUpdate();
            

    }

    //Player Lv Up and Down Button Controlls
    public void PlLvButtonIncrease()
    {

        if (playerStats._pLevel >= playerStats._pMaxLvl)
        {
            ButtonUnableSFX();
            playerStats._pLevel = playerStats._pMaxLvl;
        }
        else if (playerStats._pLevel < playerStats._pMaxLvl)
        {
            PlayerLvUpStatIncrease();
            ButtonSFX();
        }
    }
    public void PlLvButtonDecrease()
    {
        if (playerStats._pLevel <= playerStats._pMinLvl)
        {
            ButtonUnableSFX();
            playerStats._pLevel = playerStats._pMinLvl;
        }
        else if (playerStats._pLevel <= playerStats._pMaxLvl)
        {
            PlayerLvDownStatIncrease();
            ButtonSFX();
        }
    }

    // Enemy Button Controller
    public void EnHButtonIncrease()
    {
        if (enemyStats._health > enemyStats._eMaxAmount)
        {
            enemyStats._health = enemyStats._eMaxAmount;
            ButtonUnableSFX();
           
        }
        else if (enemyStats._health < enemyStats._eMaxAmount)
        {
            enemyStats._health++;   
            ButtonSFX();
            StatTextUpdate();
        }
    }
    public void EnHButtonDecrease()
    {
        if (enemyStats._health <= enemyStats._eMinAmount)
        {
            ButtonUnableSFX();
            enemyStats._health = enemyStats._eMinAmount;
        }
        else if (enemyStats._health > enemyStats._eMinAmount)
        {
            ButtonSFX();
            enemyStats._health--;
            StatTextUpdate();
        }    
    }

    public void EnDButtonIncrease()
    {
        if (enemyStats._defence > enemyStats._eMaxAmount)
        {
            ButtonUnableSFX();
            enemyStats._defence = enemyStats._eMaxAmount;
        }
        else if (enemyStats._defence < enemyStats._eMaxAmount)
        {
            ButtonSFX();
            enemyStats._defence++;
            StatTextUpdate();
        }
        
    }
    public void EnDButtonDecrease()
    {

        if (enemyStats._defence <= enemyStats._eMinAmount)
        {
            ButtonUnableSFX();
            enemyStats._defence = enemyStats._eMinAmount;
        }
        else if (enemyStats._defence > enemyStats._eMinAmount)
        {
            
            ButtonSFX();
            enemyStats._defence--;
            StatTextUpdate();
        }
    }
   

    //Player Attack Button
    public void PlayerAttackButton()
    {
        statCalculation.PlayerAttackMove();
    }
    
    //Stats Calculator Button
    
    public void StatCalculator()
    {
        statCalculation.EnemyCalculations();
        statCalculation.PlayerDamageCalculations();
    }

    //Reward Button Calculator Button
    public void RewardButtonCalculator()
    {
        itemSpawner.ItemReset();
        rewardCalculator.PlayerResourceChecker();
        rewardCalculator.PlayerLevelChecker();
        rewardCalculator.ArmourDifChecker();
        rewardCalculator.WeaponDifToTypeChecker();
        rewardCalculator.CombinedRewardPoints();
        StatTextUpdate();
        PlayerAttackButton();
    }

    public void RewardSpawner()
    {
        if (playerStats._playerRewardPoints < rewardCalculator._noReward )
        {
            itemSpawner.NoRewardSpawner();
        }
        else if (playerStats._playerRewardPoints < rewardCalculator._badReward )
        {
            itemSpawner.BadRewardSpawner();
        }
        else if (playerStats._playerRewardPoints < rewardCalculator._okReward )
        {
            itemSpawner.OkRewardSpawner();
        }
        else if (playerStats._playerRewardPoints < rewardCalculator._goodReward )
        {
            itemSpawner.GoodRewardSpawner();
        
        }
        else if (playerStats._playerRewardPoints > rewardCalculator._goodReward)
        {
            itemSpawner.LegendaryRewardSpawner();
        }
    }

    //Button SFX
    public void ButtonSFX()
    {
        AudioManager.Play("ButtonPressed");
    }public void ButtonUnableSFX()
    {
        AudioManager.Play("ButtonUnableToPress");
    }

    
}
