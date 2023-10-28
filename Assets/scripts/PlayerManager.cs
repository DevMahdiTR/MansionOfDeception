using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private RectTransform chat;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] private TMP_Text npcName;
    [SerializeField] private Image image;
    [SerializeField] private AudioSource audio;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
  
    public UnityEvent OnKeyDown;
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj  = collision.gameObject;

        if(obj.gameObject.CompareTag("NPC"))
        {
            npcName.text = obj.name;
            var routine = StartCoroutine(CheckKeyRoutine ());

            if (obj.gameObject.name.Equals("Sophia Davis"))
            {
                turnOffAll();
                gameObjects[0].SetActive(true);
                image.sprite = sprites[0];

            }
            else if (obj.gameObject.name.Equals("Nathan Brown"))
            {
                turnOffAll();
                gameObjects[1].SetActive(true);
                image.sprite = sprites[1];
            }
            else if (obj.gameObject.name.Equals("Daniel Smith"))
            {
                turnOffAll();
                gameObjects[2].SetActive(true);
                image.sprite = sprites[2];
            }
            else if (obj.gameObject.name.Equals("Robert Johnson"))
            {
                turnOffAll();
                gameObjects[3].SetActive(true);
                image.sprite = sprites[3];
            }
        }
        if(obj.gameObject.CompareTag("documents"))
        {
            var t = obj.gameObject.GetComponent<Documents>();
            if(t != null)
            {
                t.Open();
                audio.Play();
                
            }
            Debug.Log("gzergze");
        }
    }

    

    private void turnOffAll()
    {
        foreach(var obj in gameObjects)
        {
            obj.SetActive(false);
        }
    }
    private IEnumerator CheckKeyRoutine()
    {while (true)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            chat.DOLocalMoveY(330, .5f).SetEase(Ease.InOutBack);
            playerController.enabled = false;
            audio.Play();
            OnKeyDown.Invoke();
        }
    }
    /*  private void OnTriggerExit2D(Collider2D collision)
      {
          if(collision.gameObject.CompareTag("NPC"))
              chat.transform.DOMoveY(400, 0.5f).SetEase(Ease.InOutBack);
      }*/
}
