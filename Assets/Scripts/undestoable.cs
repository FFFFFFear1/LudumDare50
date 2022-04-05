using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class undestoable : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
