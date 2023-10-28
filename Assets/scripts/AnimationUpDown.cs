using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUpDown : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private float ys , yf, xs;

    private void Start()
    {
        // Initial position (z = 0.7)
        Vector3 initialPosition = new Vector3(xs, ys,0);

        // Final position (z = 0.95)
        Vector3 finalPosition = new Vector3(xs, yf, 0);

        // Duration of the tween
        float duration = 0.5f;

        // SetEase to InOutBack
        DOTween.To(() => initialPosition, x => obj.transform.DOLocalMove(x, duration), finalPosition, duration)
            .SetEase(Ease.Unset)
            .SetLoops(-1, LoopType.Yoyo);
    }
}