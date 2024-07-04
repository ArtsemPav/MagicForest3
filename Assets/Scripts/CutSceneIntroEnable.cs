using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneIntroEnable : MonoBehaviour
{

    public GameObject thePlayer;
    public GameObject cutscenecamera;
    public GameObject thecutscene;
    public float videolenght = 37f;

    void Start()
    {
        cutscenecamera.SetActive(true);
        thePlayer.SetActive(false);
        thecutscene.SetActive(true);
        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(videolenght);
        thePlayer.SetActive(true);
        cutscenecamera.SetActive(false);       
        thecutscene.SetActive(false);
    }
}
