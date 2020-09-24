using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TMPro;


public class ITController : MonoBehaviour,  ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public new AudioSource audio;
    public GameObject findText;
    private bool started;
    public TMP_Text texto;
    Animator _evil;
    private int score = 0;
    private int evilScore = 0;

 

    void Start()
    {
        //texto = GameObject.Find("Canvaso").GetComponentInChildren<TMP_Text>();
       _evil = GameObject.Find("oracle").GetComponentInChildren<Animator>();
        
        score = ScoreRange.CardScore;
        evilScore = score * 9;
        texto = this.gameObject.GetComponentInChildren<TMP_Text>();

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        started = false;

        Debug.Log(ScoreRange.CardScore);
    }


    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            //Debug.Log(mTrackableBehaviour.TrackableName);
            //texto.text = mTrackableBehaviour.name;
            // Play audio when target is found
          
            if (!started)
            {

                //audio.Play();
                //findText.gameObject.SetActive(false);
               
                started = true;
                if (evilScore > 0 && evilScore <= 74)
                {
                    _evil.SetInteger("goTo", 1);
                    texto.text = 1.ToString();
                }
                if (evilScore > 74 && evilScore <= 148)
                {
                    _evil.SetInteger("goTo", 2);
                    texto.text = 2.ToString();
                }
                if (evilScore > 148 && evilScore <= 222)
                {
                    _evil.SetInteger("goTo", 3);
                    texto.text = 3.ToString();
                }
                if (evilScore > 222 && evilScore <= 296)
                {
                    _evil.SetInteger("goTo", 4);
                    texto.text = 4.ToString();
                }
                if (evilScore > 296 && evilScore <= 370)
                {
                    _evil.SetInteger("goTo", 5);
                    texto.text = 5.ToString();
                }
                if (evilScore > 370 && evilScore <= 444)
                {
                    _evil.SetInteger("goTo", 6);
                    texto.text = 6.ToString();
                }
                if (evilScore > 444 && evilScore <= 518)
                {
                    _evil.SetInteger("goTo", 7);
                    texto.text = 7.ToString();
                }
                if (evilScore > 518 && evilScore <= 592)
                {
                    _evil.SetInteger("goTo", 8);
                    texto.text = 8.ToString();
                }
                if (evilScore > 592)
                {
                    _evil.SetInteger("goTo", 9);
                    texto.text = 9.ToString();
                }

            }
        }
        else
        {
            // Stop audio when target is lost
            //audio.Stop();
        }
    }
}
