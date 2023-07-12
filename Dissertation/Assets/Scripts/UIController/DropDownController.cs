using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownController : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] EnemyStats enemyStats;

    public int _dropDStamina;
    public int _dropDArmour;
    public int _dropDSWeapon;
    public int _dropDResources;

    public int _eDropDType;
    public int _eDropDArmour;

    // Player Drop down menu controllers
    public void DropDownStamina(int val)
    {
        if (val == 0)
        {
            playerStats._stamina = 0;
            _dropDStamina = playerStats._stamina;
            Debug.LogWarning("Stamina is set to" + " " + _dropDStamina);
        }
        if (val == 1)
        {
            playerStats._stamina = 1;
            _dropDStamina = playerStats._stamina;
            Debug.LogWarning("Stamina is set to" + " " + _dropDStamina);
        }
        if (val == 2)
        {
            playerStats._stamina = 2;
            _dropDStamina = playerStats._stamina;
            Debug.LogWarning("Stamina is set to" + " " + _dropDStamina);
        }

    }

    public void DropDownArmourSet(int val)
    {
        if (val == 0)
        {
            playerStats._armourSet = 0;
            _dropDArmour = playerStats._armourSet;
            Debug.LogWarning("Armour is set to" + " " + _dropDArmour);
        }
        if (val == 1)
        {
            playerStats._armourSet = 1;
            _dropDArmour = playerStats._armourSet;
            Debug.LogWarning("Armour is set to" + " " + _dropDArmour);
        }
        if (val == 2)
        {
            playerStats._armourSet = 2;
            _dropDArmour = playerStats._armourSet;
            Debug.LogWarning("Armour is set to" + " " + _dropDArmour);
        }

    }

    public void DropDownWeaponSet(int val)
    {
        if (val == 0)
        {
            playerStats._weapon = 0;
            _dropDSWeapon = playerStats._weapon;
            Debug.LogWarning("Weapon is set to" + " " + _dropDSWeapon);
        }
        if (val == 1)
        {
            playerStats._weapon = 1;
            _dropDSWeapon = playerStats._weapon;
            Debug.LogWarning("Weapon is set to" + " " + _dropDSWeapon);
        }
        if (val == 2)
        {
            playerStats._weapon = 2;
            _dropDSWeapon = playerStats._weapon;
            Debug.LogWarning("Weapon is set to" + " " + _dropDSWeapon);
        }

    }

    public void DropDownResources(int val)
    {
        if (val == 0)
        {
            playerStats._resourcers = 0;
            _dropDResources = playerStats._resourcers;
            Debug.LogWarning("Resources is set to" + " " + _dropDResources);
        }
        if (val == 1)
        {
            playerStats._resourcers = 1;
            _dropDResources = playerStats._resourcers;
            Debug.LogWarning("Resources is set to" + " " + _dropDResources);
        }
        if (val == 2)
        {
            playerStats._resourcers = 2;
            _dropDResources = playerStats._resourcers;
            Debug.LogWarning("Resources is set to" + " " + _dropDResources);
        }
        if (val == 3)
        {
            playerStats._resourcers = 3;
            _dropDResources = playerStats._resourcers;
            Debug.LogWarning("Resources is set to" + " " + _dropDResources);
        }
        if (val == 4)
        {
            playerStats._resourcers = 4;
            _dropDResources = playerStats._resourcers;
            Debug.LogWarning("Resources is set to" + " " + _dropDResources);
        }


    }


    // Enemy Drop Down Controllers
    public void DropDownEnemyType(int val)
    {
        if (val == 0)
        {
            enemyStats._enemyType = 0;
            _eDropDType = enemyStats._enemyType;
            Debug.LogWarning("Enemy Type is set to" + " " + _eDropDType);
        }
        if (val == 1)
        {
            enemyStats._enemyType = 1;
            _eDropDType = enemyStats._enemyType;
            Debug.LogWarning("Enemy Type is set to" + " " + _eDropDType);
        }
        if (val == 2)
        {
            enemyStats._enemyType = 2;
            _eDropDType = enemyStats._enemyType;
            Debug.LogWarning("Enemy Type is set to" + " " + _eDropDType);
        }
    }

    public void DropDownEnemyArmourSet(int val)
    {
        if (val == 0)
        {
            enemyStats._armourSet = 0;
            _eDropDArmour = enemyStats._armourSet;
            Debug.LogWarning("Enemy Armour is set to" + " " + _eDropDArmour);
        }
        if (val == 1)
        {
            enemyStats._armourSet = 1;
            _eDropDArmour = enemyStats._armourSet;
            Debug.LogWarning("Enemy Armour is set to" + " " + _eDropDArmour);
        }
        if (val == 2)
        {
            enemyStats._armourSet = 2;
            _eDropDArmour = enemyStats._armourSet;
            Debug.LogWarning("Enemy Armour is set to" + " " + _eDropDArmour);
        }

    }


}
