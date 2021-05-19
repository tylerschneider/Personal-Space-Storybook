using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class DistanceManager : MonoBehaviour
{
    // Public fields
    private float strangerDistance = 10;
    private float friendDistance = 5;
    private float familyDistance = 3;
    public GameObject guidanceCircleObject;
    private SpriteRenderer guidanceCircleSprite;
    public Sprite[] sprites;

    // Private fields
    private GameObject player;
    private float distanceToPlayer;
    public enum Classification
    {
        None, Stranger, Friend, Family
    }
    public Classification currentClassification = Classification.None;
    public Classification lastClassification = Classification.None;

    // Start is called before the first frame update
    void Start()
    {
        // Find player object in scene
        player = Camera.main.gameObject;
        guidanceCircleObject = transform.GetChild(0).gameObject;
        guidanceCircleSprite = guidanceCircleObject.GetComponent<SpriteRenderer>();

        strangerDistance *= guidanceCircleObject.transform.localScale.x;
        friendDistance *= guidanceCircleObject.transform.localScale.x;
        familyDistance *= guidanceCircleObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate distance to player
        Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 playerpos = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        distanceToPlayer = Vector3.Distance(pos, playerpos);

        //vibrate the phone when changing between circles
        if(lastClassification != currentClassification)
        {
            Handheld.Vibrate();
            lastClassification = currentClassification;
        }

        // Check distance against settings
        classifyDistance();
    }

    private void classifyDistance()
    {
        //if in stranger distance
        if (distanceToPlayer < strangerDistance && distanceToPlayer > friendDistance)
        {
            if (currentClassification != Classification.Stranger)
            {
                guidanceCircleSprite.sprite = sprites[0];
                currentClassification = Classification.Stranger;
                Debug.Log("In stranger distance");
            }
        }
        //if in friend distance
        else if (distanceToPlayer < friendDistance && distanceToPlayer > familyDistance)
        {
            if (currentClassification != Classification.Friend)
            {
                guidanceCircleSprite.sprite = sprites[1];
                currentClassification = Classification.Friend;
                Debug.Log("In family distance");
            }
        }
        //if in family distance
        else if (distanceToPlayer < familyDistance)
        {
            if (currentClassification != Classification.Family)
            {
                guidanceCircleSprite.sprite = sprites[2];
                currentClassification = Classification.Family;
                Debug.Log("In friend distance");
            }

        } else if (distanceToPlayer > strangerDistance) {
            guidanceCircleSprite.sprite = sprites[3];
                currentClassification = Classification.None;
                Debug.Log("Far away");
        }
    }
}
