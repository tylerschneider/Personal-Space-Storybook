﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private GameObject prefab;
    [SerializeField]
    private Material previewMaterial;

    public GameObject startButton;
    public GameObject placeButton;
    public GameObject confirmButton;
    public GameObject removeButton;

    private GameObject previewObject = null;
    public GameObject placedObject = null;

    public static ScenePlacer Instance;

    public Lesson lesson;

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

        prefab = lesson.placedObject;
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
                    previewObject = Instantiate(prefab);
                    //check that the guidance circle is enabled
                    if (!SettingsManager.Instance.GuidanceCircle)
                    {
                        previewObject.transform.Find("GuidanceCircle").gameObject.SetActive(false);
                    }
                    //set materials for the preview object to the preview material
                    previewObject.GetComponent<Renderer>().material = previewMaterial;
                    foreach (var renderer in previewObject.GetComponentsInChildren<Renderer>())
                    {
                        var materials = new Material[renderer.materials.Length];
                        for (var i = 0; i < materials.Length; i++)
                        {
                            materials[i] = previewMaterial;
                        }
                        renderer.materials = materials;
                    }
                }
                //show the preview object and place it at raycast hit
                previewObject.SetActive(true);
                previewObject.transform.position = pose.position;
                previewObject.transform.rotation = pose.rotation;
                previewObject.transform.forward = -previewObject.transform.forward;
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
        else if(state == PlacerState.Placed)
        {
            if(!GetComponent<AudioSource>().isPlaying)
            {
                EnableConfirmButton();
            }
        }
    }

    public void OnStartButton()
    {
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

        startButton.SetActive(false);
        placeButton.SetActive(true);
    }

    public void OnPlaceButton()
    {
        //when the player presses to put down the preview

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
            placedObject = Instantiate(prefab, pose.position, pose.rotation);
            if (!SettingsManager.Instance.GuidanceCircle)
            {
                placedObject.transform.Find("GuidanceCircle").gameObject.SetActive(false);
            }
            var anchorComponent = placedObject.AddComponent<ARAnchor>();
            anchorComponent = anchorManager.AddAnchor(pose);
            placedObject.transform.forward = -placedObject.transform.forward;

            GetComponent<AudioSource>().clip = lesson.clips[0];
            GetComponent<AudioSource>().Play();

            state = PlacerState.Placed;

            placeButton.SetActive(false);
        }
    }

    public void EnableConfirmButton()
    {
        confirmButton.SetActive(true);
    }

    public void OnConfirmButton()
    {
        //code for checking answer
        GuidanceCircle data = placedObject.GetComponent<GuidanceCircle>();
        if (data.currentClassification.ToString() == lesson.answer)
        {
            //remove all buttons
            confirmButton.SetActive(false);
            removeButton.SetActive(false);

            state = PlacerState.Done;

            GetComponent<AudioSource>().clip = lesson.clips[1];
            GetComponent<AudioSource>().Play();
        }
    }

    public void OnRemoveButton()
    {
        if (state == PlacerState.Placed)
        {
            Destroy(placedObject);
            placedObject = null;
            state = PlacerState.Placing;
        }
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MenuScene");
        MenuManager.Instance.ChangeMenu(MenuManager.Instance.transform.Find("StudentLessons").gameObject);
    }
}
