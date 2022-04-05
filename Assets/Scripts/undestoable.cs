using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class undestoable : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(1);
    }
}
