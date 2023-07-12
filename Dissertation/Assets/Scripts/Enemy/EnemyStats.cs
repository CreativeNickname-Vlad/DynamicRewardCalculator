using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    /// <summary>
    /// This is a very base player stats, for the sake of demonstarateion they have been overly simplified, but the system in general can simply be higjacked to any game
    /// as long as the correct stats have been used.
    /// </summary>

    [Header("Enemy Stats")]
    public float _health = 150;      // Base health
    public float _defence = 20;     // Base Defence
    public int _eLevel = 30;

    [Header("Enemy Stats After Cal")]
    public float _healthComb;
    public float _defenceComb;

    [Header("Enemy Min/Max Values")]
    public int _eMinAmount = 50;
    public int _eMaxAmount = 200;

    [Header("Enemy Drop Down Sets")]
    public int _enemyType = 0;    // Enemy type is the raraty ( Common, Elite, Legendary)
    public int _armourSet = 0;    // This is simple check that can be substetuted with a more complicated calculation that check a spessific value (most likley item level/item rarity) 

    [Header("Armour Value")]
    public int _armSetB = 20;
    public int _armSetA = 50;
    public int _armSetH = 100;

    [Header("Enemy Type")]
    public float _typeB = 2f;
    public float _typeA = 2.5f;
    public float _typeH = 3f;

    [Header("Enemy Animator")]
    public Animator _eAnimator;

    /// <summary>
    /// Amour set and weapon only have 3 different values for demonstartion purposes.
    /// 0 == Beginer weapon/armour set      \ x 1.2 multiplyer 
    /// 1 == Adventurer weapon/armour set   \ x 1.5 multiplyer
    /// 2 == Hero weapon/armour set         \ x 2 multiplyer
    /// This will only calculate based on the enemy if the player is overgeareg. To simplify it if PlayerGear > EnemyGear = BadLootChance and GoodLootChance If > is reversed (<)
    /// </summary>
    /// 

    public void Start()
    {
        _eAnimator = GetComponent<Animator>();
    }
}

