using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public static class ScoreRange
{

    public static int CardScore = 0;
    
}

public class Coagula : MonoBehaviour
{

    public TMP_Text texto;
    List<int> score666 = new List<int>(3);
    GameObject apaga;
    public string nombe;
    public int numbo = 0;

    // Start is called before the first frame update
    void Start()
    {
        texto = GameObject.Find("Score").GetComponentInChildren<TMP_Text>();
        apaga = GameObject.Find("borro");
        apaga.SetActive(false);
    }

    void Update()
    {
        if (texto.text == "") {
            texto.text = "000";
        } 
        else
        {
            texto.text = String.Join("",
             new List<int>(score666)
             .ConvertAll(i => i.ToString())
             .ToArray()).ToString();
        }
     
 
    }


    public void PressOne()
    {
        score666.Capacity = 3;

        nombe = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(nombe);

        if (nombe == "borro")
        {

            score666.RemoveAt(score666.Count - 1);
            Debug.Log("borro!");
            if (score666.Count == 0)
            {
                apaga.SetActive(false);
            }
        }
        else
        {
            if (score666.Count>3)
            {
                texto.text = texto.text;
            }
            else if(score666.Count<3)
            {
                apaga.SetActive(true);
                numbo = Int32.Parse(nombe);
                score666.Add(numbo);
            }
        
        }

    }

    public void SendScore()
    {
        ScoreRange.CardScore = Int32.Parse(texto.text);
        SceneManager.LoadScene("Motor9Scene");
    }
}
