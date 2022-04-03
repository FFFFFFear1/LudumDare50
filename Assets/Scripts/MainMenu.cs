using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameField;
    [SerializeField] private GameObject _playerDataObject;
    [SerializeField] private Transform _contentPlayers;

    [SerializeField] private GameObject _namePanel;
    [SerializeField] private GameObject _menu;
    [SerializeField] private Transform _panelScreenPosition;

    [SerializeField] private string BASE_URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSdD6rvpKp6R8_UiVX-jyGcT_oXVllL_ajBmnhFTcdLbBIWwwQ/formResponse";

    [SerializeField] private GoogleSheetLoader _loader;

    [Space(10)]
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _menuCamera;
    [SerializeField] private GameObject _gameCamera;
    [SerializeField] private Player _player;

    private void Awake()
    {
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
            if (string.IsNullOrEmpty(PlayerPrefs.GetString("Name")))
            {
                _menu.SetActive(true);
                _menu.GetComponent<RectTransform>().DOMoveY(_panelScreenPosition.position.y, 1.5f);
            }
            else
            {
                _namePanel.SetActive(true);
            }
            var content = Instantiate(_playerDataObject, _contentPlayers);
            content.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.Name;
            content.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.Score;
        }

        _gameCamera.SetActive(false);
        _menuCamera.SetActive(true);
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
            _menu.GetComponent<RectTransform>().DOMoveY(540, 1.5f);
        });
    }

    public void StartGame()
    {
        _menuScreen.SetActive(false);
        _gameScreen.SetActive(true);
        _gameCamera.SetActive(true);
        _menuCamera.SetActive(false);
        _player.enabled = true;
    }

    public void PostData(string Name, string Score)
    {
        StartCoroutine(Post(Name, Score, Application.systemLanguage.ToString()));
    }

    private IEnumerator Post(string name, string score, string country)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.776965170", name);
        form.AddField("entry.680325868", score);
        form.AddField("entry.672754871", country);
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
    }
}
