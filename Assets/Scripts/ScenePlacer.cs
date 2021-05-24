using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Android;

public class ScenePlacer : MonoBehaviour
{
    [SerializeField]
    private ARPlaneManager planeManager;
    [SerializeField]
    private ARPointCloudManager pointCloudManager;
    [SerializeField]
    private ARRaycastManager raycastManager;
    [SerializeField]
    private ARAnchorManager anchorManager;
    [SerializeField]
    private Material previewMaterial;

    public GameObject startButton;
    public GameObject placeButton;
    public GameObject confirmButton;
    public GameObject removeButton;
    public GameObject nextButton;
    public GameObject endScreen;
    public GameObject retryScreen;
    public GameObject backButton;
    public GameObject subtitles;
    public Text debug;

    //public bool conversationEnded = false;

    private int score = 0;

    private GameObject previewObject = null;
    public GameObject placedObject = null;

    public static ScenePlacer Instance;

    public Lesson lesson;

    public int conversationNum = 0;
    public int answerNum = 0;

    private enum PlacerState
    {
        Ready,
        Placing,
        Placed,
        Done
    }

    private PlacerState state = PlacerState.Ready;

    private void Start()
    {
        if (!Instance)
        {
            Instance = this;
        }

        //get the selected lesson data and start the lesson timer
        lesson = LessonManager.Instance.selectedLesson;
        LessonManager.Instance.ResetTimer();
        LessonManager.Instance.BeginTimer();
    }

    void OnEnable()
    {
        // Hide newly added planes, unless we are in placement mode
        planeManager.planesChanged += OnPlaneChange;
    }

    void OnDisable()
    {
        planeManager.planesChanged -= OnPlaneChange;
    }

    void OnPlaneChange(ARPlanesChangedEventArgs changes)
    {
        if (state != PlacerState.Placing && changes.added.Count > 0)
        {
            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {

        // Move the preview when in placing state
        if (state == PlacerState.Placing)
        {

            var previewHits = new List<ARRaycastHit>();
            raycastManager.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), previewHits, TrackableType.Planes);
            //if raycast hit
            if (previewHits.Count > 0)
            {
                var pose = previewHits[0].pose;
                //if no preview object yet
                if (previewObject == null)
                {
                    previewObject = Instantiate(lesson.placedObject);
                    //check that the guidance circle is enabled
                    if (!SettingsManager.Instance.GuidanceCircle)
                    {
                        previewObject.GetComponentInChildren<DistanceManager>().guidanceCircleObject.GetComponent<SpriteRenderer>().enabled = false;
                    }
                    //set materials for the preview object to the preview material
                    /*previewObject.GetComponent<Renderer>().material = previewMaterial;
                    foreach (var renderer in previewObject.GetComponentsInChildren<Renderer>())
                    {
                        var materials = new Material[renderer.materials.Length];
                        for (var i = 0; i < materials.Length; i++)
                        {
                            materials[i] = previewMaterial;
                        }
                        renderer.materials = materials;
                    }*/
                }
                //show the preview object and place it at raycast hit
                previewObject.SetActive(true);
                previewObject.transform.position = pose.position;
                previewObject.transform.rotation = pose.rotation;
            }
            else
            {
                //if no raycast hit, hide the preview object
                if (previewObject != null)
                {
                    previewObject.SetActive(false);
                }
            }
        }
    }

    public void OnStartButton()
    {

        //start placing the scene
        state = PlacerState.Placing;

        planeManager.enabled = true;
        pointCloudManager.enabled = true;
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(true);
        }
        foreach (var cloud in pointCloudManager.trackables)
        {
            cloud.gameObject.SetActive(true);
        }

        //hide start button and show place button
        startButton.SetActive(false);
        placeButton.SetActive(true);
    }

    public void OnPlaceButton()
    {
        //when the player finishes placing

        var placeHits = new List<ARRaycastHit>();
        raycastManager.Raycast(new Ray(Camera.main.gameObject.transform.position, Camera.main.gameObject.transform.forward), placeHits, TrackableType.Planes);
        if (placeHits.Count > 0)
        {
            Destroy(previewObject);
            previewObject = null;
            planeManager.enabled = false;
            pointCloudManager.enabled = false;
            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
            foreach (var cloud in pointCloudManager.trackables)
            {
                cloud.gameObject.SetActive(false);
            }
            var pose = placeHits[0].pose;
            placedObject = Instantiate(lesson.placedObject, pose.position, pose.rotation);
            if (!SettingsManager.Instance.GuidanceCircle)
            {
                placedObject.GetComponentInChildren<DistanceManager>().guidanceCircleObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            var anchorComponent = placedObject.AddComponent<ARAnchor>();
            anchorComponent = anchorManager.AddAnchor(pose);

            //start dialogue
            ConversationController conversation = subtitles.transform.GetChild(0).GetComponent<ConversationController>();
            conversation.conversation = lesson.conversations[0];
            conversation.Initialize();
            subtitles.gameObject.SetActive(true);

            state = PlacerState.Placed;

            nextButton.SetActive(true);
            placeButton.SetActive(false);
        }
    }

    public void OnNextButton()
    {
        ConversationController conversation = subtitles.transform.GetChild(0).GetComponent<ConversationController>();

        //when next button is pressed, advance to the next line if the conversation has not ended
        if (!conversation.conversationEnded)
        {
            placedObject.transform.Find("Character").GetComponent<SpriteRenderer>().sprite = conversation.conversation.lines[conversation.activeLineIndex].character.sprite;
            conversation.AdvanceLine();
        }
        //if the conversation has ended, check if there is another answer
        else
        {
            if(answerNum < lesson.answers.Length)
            {
                nextButton.SetActive(false);
                confirmButton.SetActive(true);
            }
            else
            {
                OnEndButton();
            }
        }
    }

    public void OnConfirmButton()
    {
        //when an answer is submitted
        DistanceManager data = placedObject.GetComponentInChildren<DistanceManager>();
        //if the submitted answer is correct
        if (data.currentClassification == lesson.answers[answerNum])
        {
            //add to attempts
            score += 1;

            //increase the answer number
            answerNum++;

            //remove confirm button
            confirmButton.SetActive(false);
            backButton.SetActive(false);
            //show end screen
            endScreen.SetActive(true);
            //hide speaker ui
            subtitles.transform.GetChild(0).GetComponent<ConversationController>().speakerUi.Hide();
        }
        else
        {
            //add to attempts
            score += 1;

            //mark lesson progress as not correct
            LessonManager.Instance.transform.Find(lesson.lessonName).GetComponent<Lesson>().lessonProgress = "Fail";

            confirmButton.SetActive(false);
            //show retry screen
            retryScreen.SetActive(true);
            //hide speaker ui
            subtitles.transform.GetChild(0).GetComponent<ConversationController>().speakerUi.Hide();
        }
    }

    public void OnEndButton()
    {
        //when pressing the end button when the end button is pressed or the final conversation ended
        ConversationController conversation = subtitles.transform.GetChild(0).GetComponent<ConversationController>();

        //if there is another conversation, continue to that conversation
        if (conversationNum < lesson.conversations.Length - 1)
        {
            conversationNum++;
            conversation.conversation = lesson.conversations[conversationNum];
            conversation.Initialize();
            placedObject.transform.Find("Character").GetComponent<SpriteRenderer>().sprite = conversation.conversation.lines[conversation.activeLineIndex].character.sprite;
            conversation.AdvanceLine();


            endScreen.SetActive(false);
            nextButton.SetActive(true);
            backButton.SetActive(true);
        }
        //if no more conversations
        else
        {
            LessonManager.Instance.transform.Find(lesson.lessonName).GetComponent<Lesson>().lessonProgress = "Pass";

            //if the auto lesson setting is enabled, find the next lesson and enable it
            if (SettingsManager.Instance.AutoLesson)
            {
                for (int i = 0; i < transform.childCount - 1; i++)
                {
                    if (LessonManager.Instance.transform.GetChild(i).GetComponent<Lesson>().name == lesson.name)
                    {
                        if(transform.GetChild(i + 1))
                        {
                            transform.GetChild(i + 1).GetComponent<Lesson>().lessonEnabled = true;
                        }

                    }
                }
            }

            BackButton();
        }
    }

    public void OnRemoveButton()
    {
        //destroys the placed object and starts placing again
        if (state == PlacerState.Placed)
        {
            Destroy(placedObject);
            placedObject = null;
            state = PlacerState.Placing;
        }
    }

    public void OnRetryButton()
    {
        confirmButton.SetActive(true);
        retryScreen.SetActive(false);
    }

    public void BackButton()
    {
        //if returning to the main menu, end timer and create lesson history
        LessonManager.Instance.EndTimer();
        LessonManager.Instance.CreateLessonHistory(lesson.lessonName, score, lesson.timeString());
        LessonManager.Instance.SaveEnabledLessons();
        SceneManager.LoadScene("MenuScene");
        MenuManager.Instance.ChangeMenu(MenuManager.Instance.transform.Find("StudentLessons").gameObject);
    }
}