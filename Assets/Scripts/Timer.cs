using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    bool isTiming = false;

    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!isTiming) return;

        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        isTiming = true;
    }

    public void StopTimer()
    {
        isTiming = false;
    }

    public float GetTime()
    {
        return elapsedTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartTimer();
        }
    }
}