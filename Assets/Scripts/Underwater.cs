using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater : MonoBehaviour
{
    private Collider _ObjectCollider;
    SoundManager Sm;
    // Start is called before the first frame update
    void Start()
    {
        _ObjectCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if ((_ObjectCollider.isTrigger == true) && (collision.tag == "Player"))
        {
            Sm.Forest.SetActive(false);
            Sm.Underwater.SetActive(true);
            Debug.Log("UnderWater");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
