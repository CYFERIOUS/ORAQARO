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
    private string[] dataBoard;
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
            string zona = ficha.name.Substring(1, ficha.name.Length/2);
            //Debug.Log("letra" + letter);
            dataBoard = new string[2];
            letterBoard(letter);
            //Debug.Log("zona" + zona);
            zoneBoard(zona);
            ficha.SetActive(true);
            populateList(dataBoard);
            revealDemon();

    }

    
    public void zoneBoard(string zone)
    {
        dataBoard[0] = zone;
        //Debug.Log("zona array: " + dataBoard[0].ToString());
    }
    public void letterBoard(string letter)
    {
        dataBoard[1] = letter;
        //Debug.Log("letra array: " + dataBoard[1].ToString());
        
    }
    public void populateList(string[] element)
    {
        arrayList.Add(element);
        Debug.Log(arrayList);

        foreach (object o in arrayList)
        {
            var list = (object[])o;
            Debug.Log("en la lista zona" + list[0]);
            Debug.Log("en la lista letra" + list[1]);
           
        }

    }
    public void revealDemon()
    {
        string demon;
        string s = "";
        foreach (object o in arrayList)
        {

            var list = (object[])o;
            string helper = Convert.ToChar(list[1]).ToString();
            demon = helper;
           
            s = s + demon.ToString();
            Debug.Log(demon);
            /*foreach (object e in demon)
            {
                Debug.Log(e);
            }*/

        }
        if (s.Length == magicWord.Length)
        {
            if (String.Equals(magicWord,s))
            {

                Debug.Log("MONSTRO");
                Transform firstChild = GameObject.Find("oraqaro").transform.GetChild(0);
                firstChild.gameObject.SetActive(true);
            }
        }
        

    }
}
