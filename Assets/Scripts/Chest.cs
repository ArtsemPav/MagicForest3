using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Collider _ObjectCollider;
    public Animator _anim;
    private bool chestOpen;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _ObjectCollider = GetComponent<Collider>();
        _anim.SetBool("Open", false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if ((_ObjectCollider.isTrigger == true) && (collision.tag == "Player"))
        {
            Debug.Log("Trigger On" + _ObjectCollider);
            _anim.SetBool("Open", true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
