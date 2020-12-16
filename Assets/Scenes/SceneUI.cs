using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneUI : MonoBehaviour
{
    public GameObject UIRootObject;
    public Text text; //For debug
    public GameObject SceneList;
    public GameObject MainButton;
    void Start()
    {
        DontDestroyOnLoad(UIRootObject);
        SceneManager.LoadScene("main");
    }
    
    void Update()
    {
        text.text = "Now at: " + SceneManager.GetActiveScene().name;
    }
    
    public void switchScene(String sceneName)           
    {
        if(SceneManager.GetActiveScene().name.Equals(sceneName))
            return;
        SceneList.SetActive(sceneName.Equals("main"));
        MainButton.SetActive(!sceneName.Equals("main"));
        SceneManager.LoadScene(sceneName);
    }

}
