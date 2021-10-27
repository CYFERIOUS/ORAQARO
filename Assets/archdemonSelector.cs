using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class Patron
{

    public static int archdemon = 0;

}
public class archdemonSelector : MonoBehaviour
{
    public Canvas canvas;
    Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tempObject = GameObject.Find("Menu");
        canvas = tempObject.GetComponent<Canvas>();
        buttons = canvas.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            int closureIndex = i; // Prevents the closure problem
            buttons[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
        }
    }

    private void TaskOnClick(int closureIndex)
    {
        Debug.Log("You have clicked the button #" + buttons[closureIndex].name, buttons[closureIndex]);
        Patron.archdemon = Int32.Parse(buttons[closureIndex].name);
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
