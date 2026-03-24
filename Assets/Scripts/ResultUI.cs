using UnityEngine;
using TMPro;

public class ResultUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public void ShowResult()
    {
        float time = Timer.instance.GetTime();

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}