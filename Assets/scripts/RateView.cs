using UnityEngine;
using TMPro;
using Telegram.WebApp;

public class RateView: MonoBehaviour
{
    public TextMeshProUGUI rate;
    public TextMeshProUGUI name;
    public TextMeshProUGUI score;
    public void SetPlayerInfo(UserInfo user)
    {
        rate.text = user.rate;
        name.text = user.username;
        score.text = user.score;
    }
}