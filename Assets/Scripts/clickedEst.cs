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
    string magicWord = "REYBAELOUS";


    public Canvas canvas;
    public Text myText;
    public Text nominous;
    public Text position;
    private int archdaemon;
    Button[] buttons;
    



    void Start()
    {
        archdaemon = Patron.archdemon;
       
        GameObject tempObject = GameObject.Find("Zona");
        canvas = tempObject.GetComponent<Canvas>();

        nominous.text = magicWord;
        position.text = "";

        //canvas = (Canvas)GameObject.FindObjectOfType(typeof(Canvas));
        buttons = canvas.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            int closureIndex = i; // Prevents the closure problem
            buttons[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
        }
        

    }

    private void Update()
    {
        /*if (Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
               nominous.text = Hit.transform.name;
               Debug.Log(Hit.transform.name);
            }
        }*/
    }

    private void TaskOnClick(int buttonIndex)
    {
      
            //Debug.Log("You have clicked the button #" + buttons[buttonIndex].name, buttons[buttonIndex]);
            GameObject ficha = buttons[buttonIndex].transform.GetChild(0).gameObject;
            position.text = ficha.name;
            string letter = ficha.name.Substring(0, ficha.name.Length/2);
            string zona = ficha.name.Substring(1, ficha.name.Length/2);
            //Debug.Log("letra" + letter);
            dataBoard = new string[3];
            letterBoard(letter);
            //Debug.Log("zona" + zona);
            zoneBoard(zona);
            GameObject totem =  ficha.transform.GetChild(archdaemon).gameObject;
            Debug.Log("totem" + totem.name);
            totem.SetActive(true);
            
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
            var aSet = new HashSet<char>(s);
            var bSet = new HashSet<char>(magicWord);
            bool abSame = aSet.SetEquals(magicWord);
            if (abSame)
            {

                Debug.Log("MONSTRO");
                Transform firstChild = GameObject.Find("oraqaro").transform.GetChild(0);
                firstChild.gameObject.SetActive(true);
            }
        }
        

    }
}
