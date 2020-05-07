using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidanceCircle : MonoBehaviour
{
    // Public fields
    public Material[] materials;
    public float strangerDistance = 10;
    public float friendDistance = 5;
    public float familyDistance = 3;
    public GameObject guidanceCircleObject;
    public SpriteRenderer guidanceCircleSprite;
    public Sprite[] sprites;

    // Private fields
    private GameObject player;
    private float distanceToPlayer;
    private enum Classification
    {
        Stranger, Friend, Family, None
    }
    private Classification currentClassification;

    // Start is called before the first frame update
    void Start()
    {
        // Find player object in scene
        /* foreach (var go in this.gameObject.scene.GetRootGameObjects())
        {
            if (go.tag == "MainCamera") {
                player = go;
            }
        } */
        player = Camera.main.gameObject;
        currentClassification = Classification.None;
        //InvokeRepeating("classifyDistance", 1f, 1f);
        guidanceCircleSprite = guidanceCircleObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate distance to player
        distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        Debug.Log("Distance to player: " + distanceToPlayer);

        // Check distance against settings
        classifyDistance();
    }

    private void classifyDistance()
    {
        if (distanceToPlayer < strangerDistance && distanceToPlayer > friendDistance)
        {
            if (currentClassification != Classification.Stranger)
            {
                GetComponent<Renderer>().material = materials[0];
                guidanceCircleSprite.sprite = sprites[0];
                currentClassification = Classification.Stranger;
                Debug.Log("In stranger distance");
            }
        }
        else if (distanceToPlayer < friendDistance && distanceToPlayer > familyDistance)
        {
            if (currentClassification != Classification.Friend)
            {
                GetComponent<Renderer>().material = materials[1];
                guidanceCircleSprite.sprite = sprites[1];
                currentClassification = Classification.Friend;
                Debug.Log("In family distance");
            }
        }
        else if (distanceToPlayer < familyDistance)
        {
            if (currentClassification != Classification.Family)
            {
                GetComponent<Renderer>().material = materials[2];
                guidanceCircleSprite.sprite = sprites[2];
                currentClassification = Classification.Family;
                Debug.Log("In friend distance");
            }
        } else if (distanceToPlayer > strangerDistance) {
            GetComponent<Renderer>().material = materials[3];
            guidanceCircleSprite.sprite = sprites[3];
                currentClassification = Classification.None;
                Debug.Log("Far away");
        }
    }
}
