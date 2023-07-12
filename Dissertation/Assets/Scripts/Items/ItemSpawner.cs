using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject _noReward;
    [SerializeField] GameObject _badReward;
    [SerializeField] GameObject _okReward;
    [SerializeField] GameObject _goodReward;
    [SerializeField] GameObject _legendaryReward;

    public void NoRewardSpawner()
    {
        Debug.Log(_badReward);
        _noReward.SetActive(true);
    }
    public void BadRewardSpawner()
    {
        Debug.Log(_badReward);
        _badReward.SetActive(true);
    } 
    public void OkRewardSpawner()
    {
        Debug.Log(_okReward);
        _okReward.SetActive(true);
    } 
    public void GoodRewardSpawner()
    {
        Debug.Log(_goodReward);
        _goodReward.SetActive(true);
    }
    public void LegendaryRewardSpawner()
    {
        Debug.Log(_legendaryReward.activeSelf);
        _legendaryReward.SetActive(true);
    }

    public void ItemReset()
    {
        _noReward.SetActive(false);
        _badReward.SetActive(false);
        _okReward.SetActive(false);
        _goodReward.SetActive(false);
        _legendaryReward.SetActive(false);

    }

}
