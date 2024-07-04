using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject Forest;
    public GameObject Underwater;

    // Start is called before the first frame update
    void Start()
    {
        Forest.SetActive(true);
        Underwater.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
