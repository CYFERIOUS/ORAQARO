using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class clickedEst : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] dataBoard = new string[2];

    public Canvas canvas;
    public Text myText;
    Button[] buttons;



    void Start()
    {
        canvas = (Canvas)GameObject.FindObjectOfType(typeof(Canvas));
        buttons = canvas.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            int closureIndex = i; // Prevents the closure problem
            buttons[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
        }


    }

    private void TaskOnClick(int buttonIndex)
    {
      
        Debug.Log("You have clicked the button #" + buttons[buttonIndex].name, buttons[buttonIndex]);
        
        GameObject ficha = buttons[buttonIndex].transform.GetChild(0).gameObject;
       
            myText.text = ficha.name;
        ficha.SetActive(true);
      
    }

    
    public void zoneBoard(string zone)
    {
        dataBoard[0] = zone;
        myText.text = "PIPOPEPO";
        Debug.Log("zona : " + dataBoard[0].ToString());
    }
    public void letterBoard(string letter)
    {
        Debug.Log(letter);
        dataBoard[1] = letter;
        Debug.Log("letra : " + dataBoard[1].ToString());
    }
}
