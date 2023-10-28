using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimationWin : MonoBehaviour
{
    [SerializeField] private RectTransform rect;
    [SerializeField] private Image image;
    [SerializeField] private GameObject obj;

    [SerializeField] private float y;

    private void Start()
    {
        StartCoroutine(FadeOut());
        if(rect != null )
            rect.DOMoveY(y, 0.7f).SetEase(Ease.InOutBack).SetDelay(0.5f);
    }


    public void ChangeScene(int buildIndex)
    {
        StartCoroutine(DynamicSceneChange(buildIndex));
    }

    IEnumerator FadeOut()
    {
        image.DOColor(new Color(0, 0, 0, 0), 0.5f);
        yield return new WaitForSeconds(0.6f);
        image.gameObject.SetActive(false);
    }


    IEnumerator DynamicSceneChange(int buildIndex)
    {
        image.gameObject.SetActive(true);
        image.DOColor(new Color(0, 0, 0, 1), 0.5f);
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(buildIndex);
    }
  
}
