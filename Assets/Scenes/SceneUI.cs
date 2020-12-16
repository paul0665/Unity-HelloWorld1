// /*
// MIT License
// 
// Copyright (c) $today.year Paul0665(as know as Paul)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// */

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneUI : MonoBehaviour
{

    public static bool isGamePause;
    //public static List<GameObject> EscapeMenuList = new List<GameObject>();
    private static List<GameObject> WhiteList = new List<GameObject>();
    private static List<GameObject> DisabledList = new List<GameObject>();//objects that is disable on pause
    public GameObject UIRootObject;
    public Text text; //For debug
    public GameObject SceneList;
    public GameObject MainButton;
    public GameObject QuitButton;

    private void Start()
    {
        DontDestroyOnLoad(UIRootObject);
        SceneManager.LoadScene("main");
        WhiteList.Add(text.gameObject);
    }
    private void Update()
    {
        text.text = "Now at: " + SceneManager.GetActiveScene().name;
        InputManager();
    }

    public void switchScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name.Equals(sceneName))
            return;
        SceneList.SetActive(sceneName.Equals("main"));
        MainButton.SetActive(!sceneName.Equals("main"));
        SceneManager.LoadScene(sceneName);
    }

    private void InputManager()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            //unUse child ui open check ;return;
            GamePauseMenuManager();
    }

    private void GamePauseMenuManager() //Manage game pause
    {
        if (Time.timeScale.Equals(0) && isGamePause)
        {
            print("GO");
            isGamePause = false;
            foreach (Transform uiTransform in UIRootObject.GetComponentInChildren<Transform>())
            {
                print(uiTransform.name);
                if (WhiteList.Contains(uiTransform.gameObject))
                    print(uiTransform.name + " in white list, spiked.");
                else if(!DisabledList.Contains(uiTransform.gameObject)) 
                    uiTransform.gameObject.SetActive(true);
            }
            QuitButton.SetActive(false);
            Time.timeScale = 1F;
        }
        else
        {
            print("Pause");
            isGamePause = true;
            DisabledList.Clear();
            foreach (Transform uiTransform in UIRootObject.GetComponentInChildren<Transform>())
            {
                print(uiTransform.name);
                if (WhiteList.Contains(uiTransform.gameObject))
                    print(uiTransform.name + " in white list, spiked.");
                else if(uiTransform.gameObject.activeSelf) 
                    uiTransform.gameObject.SetActive(false);
                else 
                    DisabledList.Add(uiTransform.gameObject);
            }
            QuitButton.SetActive(true);
            Time.timeScale = 0F;
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }
}