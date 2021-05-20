using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace SocicalCircle
{

    public class DropSystem : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Color highlight;
        private Color normal;
        public CharacterType type;
        public GameObject clones;
        public Text notification;
        private string lines;
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("OnDrop");
            DragSystem pointer = eventData.pointerDrag.GetComponent<DragSystem>();

            if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = pointer.startPosition;
                if (pointer.currentCharacter < pointer.maxRandomCharacter && type == pointer.randomizeCharacters[pointer.currentCharacter].characterType)
                {
                    clones.GetComponent<Image>().sprite = pointer.presentCharacter.sprite;
                    clones.GetComponent<Image>().preserveAspect = true;
                    //evenData.GetComponent<AudioSource().clip.PlayOneShot();
                    GameObject obj = Instantiate(clones, gameObject.transform);
                    obj.transform.parent = gameObject.transform;
                    pointer.currentCharacter++;
                    switch (type)
                    {
                        case CharacterType.Family:
                            StartCoroutine(sendNotify("this is your family member",3));
                            notification.color = Color.green;
                            break;
                        case CharacterType.Friend:
                            StartCoroutine(sendNotify("this is your friend", 3));
                            notification.color = Color.black;
                            break;
                        case CharacterType.Stranger:
                            StartCoroutine(sendNotify("this is a stranger", 3));
                            notification.color = Color.red;
                            break;
                        default:
                            break;
                    }

                    if(pointer.currentCharacter < pointer.maxRandomCharacter)
                    {
                        pointer.presentCharacter.sprite = pointer.randomizeCharacters[pointer.currentCharacter].characterSprite;
                        //pointer.GetComponet<AudioSource>().clip == pointer.randomizeCharacters[pointer.currentCharacter].voice;
                    }
                    else
                    {
                        pointer.gameObject.SetActive(false);
                        pointer.presentCharacter.sprite = null;
                    }
                }
            }

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            normal = this.GetComponent<Image>().color;
            this.GetComponent<Image>().color = highlight;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this.GetComponent<Image>().color = normal;
        }

        IEnumerator sendNotify(string text,int time)
        {
            notification.gameObject.SetActive(true);
            notification.text = text;
            yield return new WaitForSeconds(time);
            notification.text = "";
            notification.gameObject.SetActive(false);
        }
    }

}