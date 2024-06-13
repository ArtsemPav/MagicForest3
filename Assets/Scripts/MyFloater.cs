using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFloater : MonoBehaviour
{
    private Rigidbody rigidbody1;
    public float floatUpSpeedLimit = 1.15f;
    public float floatUpSpeed = 1f;

    private void Start()
    {
        rigidbody1 = GetComponent<Rigidbody>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            float difference = (other.transform.position.y - transform.position.y) * floatUpSpeed;
            rigidbody1.AddForce(new Vector3(0f, Mathf.Clamp((Mathf.Abs(Physics.gravity.y) * difference), 0, Mathf.Abs(Physics.gravity.y) * floatUpSpeedLimit), 0f), ForceMode.Acceleration);
            rigidbody1.drag = 0.99f;
            rigidbody1.angularDrag = 0.8f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            rigidbody1.drag = 0f;
            rigidbody1.angularDrag = 0f;
        }
    }
}