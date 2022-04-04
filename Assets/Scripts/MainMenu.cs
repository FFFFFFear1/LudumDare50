using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameField;
    [SerializeField] private GameObject _playerDataObject;
    [SerializeField] private Transform _contentPlayers;

    [SerializeField] private GameObject _namePanel;
    [SerializeField] private GameObject _menu;

    [SerializeField] private GoogleSheetLoader _loader;


    [SerializeField] private bool _loadTable;

    private void Awake()
    {
        if (!_loadTable) return;
        _loader.OnProcessData += LoadLeaderBoard;
    }

    private void LoadLeaderBoard(PlayersData data)
    {
        var cortedArr = data.PlayersOptionsList.OrderByDescending(x => ParseFloat(x.Score)).ToList();

        foreach (PlayersOptions player in cortedArr)
        {
            var w = cortedArr.Where(x => x != player).ToList(); 
            foreach (PlayersOptions playerW in w)
            {
                if(playerW.Name.Equals(player.Name)) {
                    if(ParseFloat(playerW.Score) > ParseFloat(player.Score))
                    {
                        cortedArr = w;
                    }
                }
            }
        }


        foreach (var playerData in cortedArr)
        {
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("Name")))
            {
                _menu.SetActive(true);
                _namePanel.SetActive(false);
                //_menu.GetComponent<RectTransform>().DOMoveY(_panelScreenPosition.position.y, 1.5f);
            }
            else
            {
                _namePanel.SetActive(true);
            }
            var content = Instantiate(_playerDataObject, _contentPlayers);
            content.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.Name;
            content.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.Score;
        }

    }
    private float ParseFloat(string s)
    {
        float result = -1;
        if (!float.TryParse(s, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out result))
        {
            //Debug.Log("Can't pars float,wrong text ");
        }

        return result;
    }

    public void InitPlayer()
    {
        if(string.IsNullOrEmpty(_nameField.text)) return;
        var Name = _nameField.text;
        PlayerPrefs.SetString("Name", Name);
        _namePanel.GetComponent<RectTransform>().DOMoveY(1800, 1.5f).OnComplete(() =>
        {
            _menu.SetActive(true);
           // _menu.GetComponent<RectTransform>().DOMoveY(540, 1.5f);
        });
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
