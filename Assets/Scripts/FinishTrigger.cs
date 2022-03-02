using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
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
        }
    }
}
