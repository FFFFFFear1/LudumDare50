using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private string BASE_URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSdD6rvpKp6R8_UiVX-jyGcT_oXVllL_ajBmnhFTcdLbBIWwwQ/formResponse";

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
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
