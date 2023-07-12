using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, 15f * Time.deltaTime, 0f, Space.Self);
    }
}
