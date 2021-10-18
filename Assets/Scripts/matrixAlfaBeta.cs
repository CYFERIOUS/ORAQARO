using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class matrixAlfaBeta : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Button yourButton;
    List<string[]> motor666 = new List<string[]>();
    void Start()
    {
        
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        
        Debug.Log("You have clicked the button B");
    }

    // Update is called once per frame
    void Update()
    {
        string name1 = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name1);

    }
   

}
