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
                    GameObject obj = Instantiate(clones, gameObject.transform);
                    obj.transform.parent = gameObject.transform;
                    pointer.currentCharacter++;
                    Debug.Log(pointer.currentCharacter);
                    Debug.Log(pointer.maxRandomCharacter);
                    if(pointer.currentCharacter < pointer.maxRandomCharacter)
                    {
                        pointer.presentCharacter.sprite = pointer.randomizeCharacters[pointer.currentCharacter].characterSprite;
                    }
                    else
                    {
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
    }

}