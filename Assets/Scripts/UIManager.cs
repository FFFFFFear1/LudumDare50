using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HPText;
    [SerializeField] private TextMeshProUGUI SpeedText;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.ChangedHP += UpdateHP;
        _player.ChangedSpeed += UpdateSpeed;
    }

    private void UpdateHP()
    {
        HPText.text = $"HP: {_player.HP}%";
    }

    private void UpdateSpeed()
    {
        SpeedText.text = $"Speed: {(_player.Speed < 0 ? _player.Speed * -1 : 0).ToString("f0")} M/h";
    }
}
