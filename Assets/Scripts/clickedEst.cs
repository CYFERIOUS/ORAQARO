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
    List<string[]> arrayList = new List<string[]>();
    string magicWord = "DAEMONOS";

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
      
        //Debug.Log("You have clicked the button #" + buttons[buttonIndex].name, buttons[buttonIndex]);
        
        GameObject ficha = buttons[buttonIndex].transform.GetChild(0).gameObject;
       
            myText.text = ficha.name;
            string letter = ficha.name.Substring(0, ficha.name.Length/2);
            string zona = ficha.name.Substring(1, ficha.name.Length / 2);
            //Debug.Log("letra" + letter);
            letterBoard(letter);
            //Debug.Log("zona" + zona);
            zoneBoard(zona);
            ficha.SetActive(true);
            populateList(dataBoard);
      
    }

    
    public void zoneBoard(string zone)
    {
        dataBoard[0] = zone;
        Debug.Log("zona array: " + dataBoard[0].ToString());
    }
    public void letterBoard(string letter)
    {
        dataBoard[1] = letter;
        Debug.Log("letra array: " + dataBoard[1].ToString());
    }
    public void populateList(string[] element)
    {
        arrayList.Add(element);
        
        foreach (object o in arrayList)
        {
            var list = (object[])o;
            Debug.Log("en la lista" + list[0]);
        }
    }
}
