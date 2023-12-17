using TMPro;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class HighscoreWatcher : MonoBehaviour
{
    public TextMeshProUGUI leaderboardText;

    void Update()
    {
        UpdateTime();
        UpdateLeaderboard();
    }

    private void UpdateLeaderboard()
    {
        if (leaderboardText == null)
            return;
        string text = @"<b>Tutorial Time:</b> " + FormatMilliseconds(ScoreManager.instance.tutorialTime) + "<br>"
            + @"<b>Mabini Time:</b> " + FormatMilliseconds(ScoreManager.instance.mabiniTime) + "<br>"
            + @"<b>Malvar Time:</b> " + FormatMilliseconds(ScoreManager.instance.malvarTime) + "<br>"
            + @"<b>Bauan Time:</b> " + FormatMilliseconds(ScoreManager.instance.bauanTime) + "<br>"
            + @"<b>San Jose Time:</b> " + FormatMilliseconds(ScoreManager.instance.sanJoseTime) + "<br>"
            + @"<b>Lobo Time:</b> " + FormatMilliseconds(ScoreManager.instance.loboTime) + "<br>"
            + @"<b>Balayan Time:</b> " + FormatMilliseconds(ScoreManager.instance.balayanTime) + "<br>"
            + @"<b>Highest Money:</b> " + ScoreManager.instance.highestMoney + "<br>"
            + @"<b>Highest Gas:</b> " + ScoreManager.instance.highestGas + "<br>";
        leaderboardText.text = text;
    }

    private void UpdateTime()
    {
        float deltaTimeMilliseconds = Time.deltaTime * 1000.0f;
        DataManager.instance.Time += deltaTimeMilliseconds;
        DataManager.instance.Save();
    }

    public static string FormatMilliseconds(float milliseconds)
    {

        string formattedTime = "";

        if (milliseconds != float.MaxValue)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(milliseconds);

            if (timeSpan.Days > 0)
            {
                formattedTime += $"{timeSpan.Days} {(timeSpan.Days == 1 ? "day" : "days")}, ";
            }

            if (timeSpan.Hours > 0)
            {
                formattedTime += $"{timeSpan.Hours} {(timeSpan.Hours == 1 ? "hour" : "hours")}, ";
            }

            if (timeSpan.Minutes > 0)
            {
                formattedTime += $"{timeSpan.Minutes} {(timeSpan.Minutes == 1 ? "minute" : "minutes")}, ";
            }

            if (timeSpan.Seconds > 0)
            {
                formattedTime += $"{timeSpan.Seconds} {(timeSpan.Seconds == 1 ? "second" : "seconds")}";
            }

            formattedTime = formattedTime.TrimEnd(',', ' ');
        }

        if (formattedTime == "")
            formattedTime = "N/A";

        return formattedTime;
    }
}
