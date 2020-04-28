using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject lastMenu;
    public static MenuManager Instance;
    public GameObject createPinScreen;
    public InputField checkPinInput;
    public GameObject checkPinError;
    public InputField checkPinInput2;
    public GameObject checkPinError2;
    public InputField createPinInput1;
    public InputField createPinInput2;
    public Text lessonTitle;
    public Text lessonText;
    public GameObject lessonMenu;
    public NoteMenuManager noteMenuManager;


    private void Start()
    {
        if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        if(GetPin() == 0)
        {
            ChangeMenu(createPinScreen);
        }
    }

    public void ChangeMenu(GameObject selectedMenu)
    {
        print(selectedMenu);

        foreach (Transform menu in transform)
        {
            if(menu.gameObject.name != "Background")
            {
                if(menu.gameObject != selectedMenu && menu.gameObject.activeSelf)
                {
                    menu.gameObject.SetActive(false);
                    lastMenu = menu.gameObject;
                }
                else if(menu.gameObject == selectedMenu)
                {
                    menu.gameObject.SetActive(true);
                }
            }

        }
    }

    public void LessonMenu(GameObject lesson)
    {
        lessonTitle.text = lesson.name;
        lessonText.text = lesson.GetComponent<Lesson>().lessonText.text;

        ChangeMenu(lessonMenu);
    }

    public void CheckPin(GameObject selectedMenu)
    {
        if(GetPin().ToString() == checkPinInput.text)
        {
            ChangeMenu(selectedMenu);
            checkPinError.SetActive(false);
            checkPinInput.text = "";
        }
        else
        {
            checkPinError.SetActive(true);
        }
    }

    public void ClearPin()
    {
        checkPinError.SetActive(false);
        checkPinInput.text = "";
    }

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

        pin.pinNumber = int.Parse(input.GetComponent<InputField>().text);

        print(Application.persistentDataPath);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/userdata.save");
        bf.Serialize(file, pin);
        file.Close();

        input.GetComponent<InputField>().text = "";
    }

    public int GetPin()
    {
        if (File.Exists(Application.persistentDataPath + "/userdata.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/userdata.save", FileMode.Open);
            PIN pin = (PIN)bf.Deserialize(file);
            file.Close();

            int pinNumber = pin.pinNumber;

            return pinNumber;
        }
        else
        {
            Debug.Log("No game saved!");

            return 0;
        }
    }
}
