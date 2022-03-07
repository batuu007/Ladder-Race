using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private Animator myAnimitor;
    private void OnTriggerEnter(Collider other)
    {
       StartCoroutine(WillTriggeredFinish(other));
    }

    IEnumerator WillTriggeredFinish(Collider other)
    {
        yield return new WaitForSeconds(2f);
        if (other.CompareTag("Stickman"))
        {
            Level.Instance.ControlMovementAndPanel();
            myAnimitor.SetTrigger("FinishDance");
        }
    }
}
