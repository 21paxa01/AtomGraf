using UnityEngine;
using TMPro;
using Telegram.WebApp;
using UnityEngine.UI;

public class RateView: MonoBehaviour
{
    public TextMeshProUGUI rate;
    public TextMeshProUGUI name;
    public TextMeshProUGUI score;
    public Image image;
    public bool test;
    public void SetPlayerInfo(UserInfo user)
    {
        rate.text = user.rate;
        name.text = user.username;
        score.text = user.score;
    }
    public void ImageColor()
    {
        image.color = new Color(0.5f, 0.5f,0.5f);
        test = true;
    }
}