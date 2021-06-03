using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

    public class DragSystem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] public Canvas canvas;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        public List<Character> characters;
        public List<Character> randomizeCharacters;
        public Image presentCharacter;
        //public AudioClip voice;
        public int currentCharacter;
        public Vector2 startPosition;
    private Vector2 startPos;

    public void StartMinigame()
        {
            if(startPos == Vector2.zero)
            {
            startPos = transform.position;
            }

            transform.position = startPos;

            gameObject.SetActive(true);
            MenuManager.Instance.transform.Find("MiniGame").Find("EndScreen").gameObject.SetActive(false);
            MenuManager.Instance.transform.Find("MiniGame").Find("BackButton").gameObject.SetActive(true);

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        presentCharacter = GetComponent<Image>();


        startPosition = rectTransform.anchoredPosition;

        characters = LessonManager.Instance.selectedLesson.characters;
            currentCharacter = 0;

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        randomizeCharacters = characters;

            for (int i = 0; i < characters.Count; i++)
            {
                Character temp = characters[i];
                int rand = Random.Range(i, characters.Count);
                randomizeCharacters[i] = characters[rand];
                randomizeCharacters[rand] = temp;
            }

            //this.getComponent<AudioSource>().clip = voice;
            GetComponent<Image>().sprite = randomizeCharacters[currentCharacter].sprite;
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
