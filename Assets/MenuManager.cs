using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject[] menus;
    public GameObject lastMenu;
    public static MenuManager Instance;
    public GameObject mainMenu;
    public GameObject createPinScreen;
    public InputField checkPinInput;
    public GameObject checkPinError;
    public Text lessonTitle;
    public Text lessonText;
    public GameObject lessonMenu;


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

        foreach (GameObject menu in menus)
        {
            if(menu != selectedMenu && menu.activeSelf)
            {
                menu.SetActive(false);
                lastMenu = menu;
            }
            else if(menu == selectedMenu)
            {
                menu.SetActive(true);
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

        ChangeMenu(mainMenu);
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
