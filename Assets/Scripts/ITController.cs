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


    void Start()
    {
        //texto = GameObject.Find("Canvaso").GetComponentInChildren<TMP_Text>();
    
        texto = this.gameObject.GetComponentInChildren<TMP_Text>();

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        started = false;
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log(mTrackableBehaviour.TrackableName);
            texto.text = mTrackableBehaviour.name;
            // Play audio when target is found
            if (!started)
            {
               
                audio.Play();
                findText.gameObject.SetActive(false);
                started = true;
            }
        }
        else
        {
            // Stop audio when target is lost
            //audio.Stop();
        }
    }
}
