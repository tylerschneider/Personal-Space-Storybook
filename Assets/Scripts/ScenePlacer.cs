using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

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

    private GameObject previewObject = null;
    private GameObject placedObject = null;

    private enum PlacerState
    {
        Ready,
        Placing,
        Placed,
    }

    private PlacerState state = PlacerState.Ready;

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
        // TODO allow dragging to rotate
        if (state == PlacerState.Placing)
        {
            var previewHits = new List<ARRaycastHit>();
            raycastManager.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), previewHits, TrackableType.Planes);
            if (previewHits.Count > 0)
            {
                var pose = previewHits[0].pose;
                if (previewObject == null)
                {
                    previewObject = Instantiate(prefab);
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
                previewObject.SetActive(true);
                previewObject.transform.position = pose.position;
                previewObject.transform.rotation = pose.rotation;
                previewObject.transform.forward = -previewObject.transform.forward;
            }
            else
            {
                if (previewObject != null)
                {
                    previewObject.SetActive(false);
                }
            }
        }
    }

    public void OnButton(Text buttonText)
    {
        switch (state)
        {
            case PlacerState.Ready:     // "Place Object" clicked
                state = PlacerState.Placing;
                buttonText.text = "Confirm";
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
                break;
            case PlacerState.Placing:   // "Confirm" clicked
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
                    if(!SettingsManager.Instance.GuidanceCircle)
                    {
                        placedObject.transform.Find("GuidanceCircle").gameObject.SetActive(false);
                    }
                    var anchorComponent = placedObject.AddComponent<ARAnchor>();
                    anchorComponent = anchorManager.AddAnchor(pose);
                    placedObject.transform.forward = -placedObject.transform.forward;
                    // DontDestroyOnLoad(placedObject);
                    state = PlacerState.Placed;
                    buttonText.text = "Remove Object";
                }
                break;
            case PlacerState.Placed:    // "Remove Object" clicked
                state = PlacerState.Ready;
                buttonText.text = "Place Object";
                Destroy(placedObject);
                break;
        }
    }
}
