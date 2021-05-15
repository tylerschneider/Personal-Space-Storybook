using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SocicalCircle
{

    public class DragSystem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] public Canvas canvas;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        public List<ScriptableCharacters> characters;
        public List<ScriptableCharacters> randomizeCharacters;
        public Image presentCharacter;
        public int currentCharacter;
        public int maxRandomCharacter;
        public int totalCharacter;
        public Vector2 startPosition;
        private void Awake()
        {
            currentCharacter = 0;
            totalCharacter = characters.Count;
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            presentCharacter = GetComponent<Image>();
            HashSet<int> randomNumbers = new HashSet<int>();
            while (randomNumbers.Count < maxRandomCharacter)
            {
                randomNumbers.Add(Random.Range(1, 5));
            }
            foreach (int i in randomNumbers)
            {
                randomizeCharacters.Add(characters[i - 1]);
                Debug.Log(i);
            }


            this.GetComponent<Image>().sprite = randomizeCharacters[currentCharacter].characterSprite;
            startPosition = rectTransform.anchoredPosition;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {

            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag");
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");
        }


    }

}