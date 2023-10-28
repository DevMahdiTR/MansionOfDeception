using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Documents : MonoBehaviour
{
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private Sprite sprite;

    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private TMP_Text tmp_title;
    [SerializeField] private TMP_Text tmp_description;
    [SerializeField] private Image photo;

    [SerializeField] private TMP_Text hints;

    private void setParametre()
    {
        tmp_title.text = title;
        tmp_description.text = description;
        photo.sprite = sprite;
    }

    public void Open()
    {
        setParametre();
        rectTransform.DOLocalMoveY(-45, 0.5f).SetEase(Ease.InOutBack);
        hints.text = "<s>"+ hints.text+"</s>";
        Debug.Log("Open");
    }

    public void Close()
    {
        rectTransform.DOLocalMoveY(1100, 0.5f).SetEase(Ease.InOutBack);
    }

}
