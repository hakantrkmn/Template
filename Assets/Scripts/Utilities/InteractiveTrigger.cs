using UnityEngine;
using UnityEngine.Events;

public class InteractiveTrigger : MonoBehaviour
{
    public string targetTag;
    public UnityEvent<GameObject> triggerEnter;
    public UnityEvent<GameObject> triggerStay;
    public UnityEvent<GameObject> triggerExit;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(targetTag))
            triggerEnter.Invoke(other.gameObject);
    }


    //---------------------------------------------------------------------------------
    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals(targetTag))
            triggerStay.Invoke(other.gameObject);
    }


    //---------------------------------------------------------------------------------
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals(targetTag))
            triggerExit.Invoke(other.gameObject);
    }
}
