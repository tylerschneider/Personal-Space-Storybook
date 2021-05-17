using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    //stores the previous menu
    public GameObject lastMenu;
    //the create pin menu
    public GameObject createPinScreen;
    //input for the initial create pin screen
    public InputField createPinInput1;
    //input for the change pin screen
    public InputField createPinInput2;

    //input and error gameobject for the instuctor menu check pin screen
    public InputField checkPinInput;
    public GameObject checkPinError;

    //input and error gameobject for the delete history check pin screen
    public InputField checkPinInput2;
    public GameObject checkPinError2;

    //lesson title and text for when switching to a lesson's summary
    public Text lessonTitle;
    public Text lessonText;

    //the lesson menu for displaying its summary
    public GameObject lessonMenu;

    public NoteMenuManager noteMenuManager;

    public VideoPlayer video; 


    private void Start()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //if no pin is found, the app will start on the create pin screen
        if (GetPin() == "None")
        {
            ChangeMenu(createPinScreen);
        }
    }

    public void ChangeMenu(GameObject selectedMenu)
    {
        foreach (Transform menu in transform)
        {
            //check each menu and disable the active one
            if (menu.gameObject != selectedMenu && menu.gameObject.activeSelf)
            {
                menu.gameObject.SetActive(false);
                lastMenu = menu.gameObject;
            }
            //enable the menu that was selected to be shown
            else if (menu.gameObject == selectedMenu)
            {
                menu.gameObject.SetActive(true);
            }
        }

        //don't disable the background
        if (selectedMenu != null)
        {
            transform.Find("Background").gameObject.SetActive(true);
        }
    }

    public void LessonMenu(GameObject lesson)
    {
        //when a lesson button is held down in the lesson list, set the lesson menu's title and story text to match the appropriate lesson's
        lessonTitle.text = lesson.name;
        lessonText.text = lesson.GetComponent<Lesson>().lessonText.text;

        //switch to the individual lesson menu
        ChangeMenu(lessonMenu);
    }

    //Check the PIN to get into the Instructor menu
    public void CheckPin(GameObject selectedMenu)
    {
        //get the pin and compare it to the user's input
        if (GetPin().ToString() == checkPinInput.text)
        {
            //if matching, go to the next menu
            ChangeMenu(selectedMenu);
            //clear any error and inputs
            checkPinError.SetActive(false);
            checkPinInput.text = "";
        }
        else
        {
            //display an error if the pin is wrong
            checkPinError.SetActive(true);
        }
    }

    public void ClearPin()
    {
        //clears any error and inputs if the back button is pressed on a pin screen
        checkPinError.SetActive(false);
        checkPinInput.text = "";
    }

    //Check the PIN to delete all history data
    public void CheckPin2(GameObject selectedMenu)
    {
        if (GetPin().ToString() == checkPinInput2.text)
        {
            ChangeMenu(selectedMenu);
            checkPinError2.SetActive(false);
            checkPinInput2.text = "";
        }
        else
        {
            checkPinError2.SetActive(true);
        }
    }

    public void ClearPin2()
    {
        checkPinError2.SetActive(false);
        checkPinInput2.text = "";
    }

    public void BackButton()
    {
        ChangeMenu(lastMenu);
    }

    public void SetPin(GameObject input)
    {
        PIN pin = new PIN();

        //save the user's input as the PIN number in the userData file
        pin.pinNumber = input.GetComponent<InputField>().text;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/userData.save");
        bf.Serialize(file, pin);
        file.Close();

        //clear the input
        input.GetComponent<InputField>().text = "";
    }

    public string GetPin()
    {
        //check if a saved PIN exists
        if (File.Exists(Application.persistentDataPath + "/userdata.save"))
        {
            //load the PIN and return it
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/userData.save", FileMode.Open);
            PIN pin = (PIN)bf.Deserialize(file);
            file.Close();

            string pinNumber = pin.pinNumber;

            return pinNumber;
        }
        else
        {
            //return none if no pin
            Debug.Log("No PIN saved!");

            return "None";
        }
    }

    private void Update()
    {
        //when the intro video ends for the first time, enable the buttons and prevent it from playing again
        if((ulong)video.frame == video.frameCount - 20 && video.isPlaying)
        {
            video.transform.parent.Find("InstructorStill").gameObject.SetActive(true);
            video.transform.parent.Find("StudentStill").gameObject.SetActive(true);
            video.playOnAwake = false;
        }
    }
}