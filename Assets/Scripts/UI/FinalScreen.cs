using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject panel;
    void Awake()
    {
        player.ChangedHP += TryOpenPanel;
    }
    private void OnDisable()
    {
        player.ChangedHP -= TryOpenPanel;
    }

    private void TryOpenPanel(float hp)
    {
        if (hp <= 0)
        {
            scoreText.text = "Score: " + player.Score;
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
