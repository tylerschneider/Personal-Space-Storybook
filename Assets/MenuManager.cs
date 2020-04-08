using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject[] menus;
    public GameObject lastMenu;
    public static MenuManager Instance;

    private void Start()
    {
        if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void ChangeMenu(GameObject selectedMenu)
    {
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

    public void BackButton()
    {
        ChangeMenu(lastMenu);
    }
}
