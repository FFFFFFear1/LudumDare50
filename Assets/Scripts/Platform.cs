using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    public PlatformType type;
    [SerializeField] private float _lifeTime = 5;
    [SerializeField] private Image _timerImage;
    [SerializeField] private TMP_Text _timerText;
    private void OnMouseDown()
    {
        if(Input.GetMouseButton(0))
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        StartCoroutine(StartPlatformBreak());
    }
    private IEnumerator StartPlatformBreak()
    {
        _timerImage.fillAmount = 1;
        float timer = _lifeTime;
        float seconds = _lifeTime / 60;
        while (timer >= 0)
        {
            _timerImage.fillAmount = timer/_lifeTime;
            _timerText.text = (int)timer+1 + "";
            timer -= seconds;
            yield return new WaitForSeconds(seconds);
        }
        gameObject.SetActive(false);
    }


}
