using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickedEst : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] dataBoard = new string[2];

    public Canvas canvas;
    //public Canvas canvas2;

    void Start()
    {
        canvas = (Canvas)GameObject.FindObjectOfType(typeof(Canvas));

    }

    public void OnButtonClick()
    {
     
        var go = EventSystem.current.currentSelectedGameObject;
        if (go != null)
        {
            //Debug.Log("Clicked on : " + go.name);
            if (canvas.name == "Zona")
            {
                zoneBoard(go.name);
            }
            if (canvas.name == "Ouija")
            {
               
                letterBoard(go.name);
            }

        }

        else
        {
            Debug.Log("currentSelectedGameObject is null");
        }
           
    }
    public void zoneBoard(string zone)
    {
        dataBoard[0] = zone;
        Debug.Log("zona : " + dataBoard[0].ToString());
    }
    public void letterBoard(string letter)
    {
        Debug.Log(letter);
        dataBoard[1] = letter;
        Debug.Log("letra : " + dataBoard[1].ToString());
    }
}
