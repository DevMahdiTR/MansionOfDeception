
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text countdownText;
    public float countdownDurationInMinutes = 5.0f; // Set the countdown duration in minutes
    private float currentTimeInSeconds;
    [SerializeField] private RectTransform rect;

    [SerializeField] private AudioSource audio;
    [SerializeField] private Button close;

    private void Start()
    {
        currentTimeInSeconds = countdownDurationInMinutes * 60;
        UpdateTimerText();
    }

    private void Update()
    {
        if (currentTimeInSeconds > 0)
        {
            currentTimeInSeconds -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            openChose();
            close.interactable = false;
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTimeInSeconds / 60);
        int seconds = Mathf.FloorToInt(currentTimeInSeconds % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void fadeOut()
    {
        audio.Play();
    }

    public void openChose()
    {
        rect.DOScale(1, 0.5f).SetEase(Ease.InOutBack);
    }
    public void CloseChoice()
    {
        rect.DOScale(0, 0.5f).SetEase(Ease.InOutBack);
    }
}
