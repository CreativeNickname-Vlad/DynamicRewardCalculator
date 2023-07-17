using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    /// <summary>
    /// This is a very base player stats, for the sake of demonstarateion they have been overly simplified, but the system in general can simply be higjacked to any game
    /// as long as the correct stats have been used.
    /// </summary>

    [Header("Plaer Stats")]
    public float _health        = 100;   // Base health
    public float _defence       = 20;    // Base Defence
    public float _strenghtBase  = 30;    // Base attack strenght, but the name can be substetuted with strenght as well
    public int   _pLevel        = 1;

    [Header("Plaer Min/Max Values")]
    public int   _pMaxLvl       = 30;
    public int   _pMinLvl       = 1;
    public int   _pMinAmount    = 1;
    public int   _pMaxAmount    = 150;
    public int   _pLvUpIncrease   = 5;


    [Header("Plaer Stats After Cal")]
    public float _strenghComb;
    public float _defenceComb;

    [Header("Plaer Damage Output")]
    public float _atkDmgOut;             // attackDamageOutput

    [Header("Plaer Drop Down Sets")]
    public int _armourSet       = 0;     // This is simple check that can be substetuted with a more complicated calculation that check a spessific value (most likley item level/item rarity) 
    public int _weapon          = 0;     // This is simple check that can be substetuted with a more complicated calculation that check a spessific value (most likley weapon level/weapon rarity) 
    public int _stamina         = 0;
    public int _resourcers      = 0;


    [Header("Armour Value")]
    public int _armSetB = 20;
    public int _armSetA = 50;
    public int _armSetH = 100;

    [Header("Weapon Value")]
    public float _wepB = 1.2f;
    public float _wepA = 1.5f;
    public float _wepH = 2f;

    [Header("Stamina Dmg Reduction")]
    public float _stamHalf = 0.75f;
    public float _stamWeak = 0.5f;

    [Header("Player Reward %")]
    public int _playerRewardPoints; //max 100

    [Header("Player Reward Values")]
    public int _resourcerRewardPoint;
    public int _levelRewardPoint;
    public int _armourRewardPoint;
    public int _wepToTypeRewardPoint;

    [Header("Player Animator")]
    public Animator _pAnimator;

    /// <summary>
    /// Amour set and weapon only have 3 different values for demonstartion purposes (armour has a set value while in the text at the botton its displayed the weapon dmg multiplyer) .
    /// 0 == Beginer weapon/armour set      \ x 1.2 multiplyer 
    /// 1 == Adventurer weapon/armour set   \ x 1.5 multiplyer
    /// 2 == Hero weapon/armour set         \ x 2 multiplyer
    /// This will only calculate based on the enemy if the player is overgeareg. To simplify it if PlayerGear > EnemyGear = BadLootChance and GoodLootChance If > is reversed (<)
    /// </summary>



    public void Start()
    {
        _pAnimator = GetComponent<Animator>();
    }
}
