using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatAnimationUI : MonoBehaviour
{
    [SerializeField] private RectTransform rect;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TMP_Text respose;
    [SerializeField] private TMP_InputField inputField;

    public void CloseChat()
    {
        rect.DOLocalMoveY(890, 0.5f).SetEase(Ease.InOutBack);
        playerController.enabled = true;
        respose.text = "Is there anything I can do to help ?";
        ResetField();
    }


    public void ResetField()
    {
        inputField.text = string.Empty;
    }

}
