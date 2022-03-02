using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUp : MonoBehaviour
{
    private bool _isClicked = true;

    void Update()
    {
        if (ForwardMovement.Instance._canMove)
        {
            if (Input.GetMouseButton(0))
            {
                _isClicked = true;
                //rb.AddForce(Vector3.up*Stack.Instance.Count,ForceMode.Impulse);
                StairLaying.Instance.KneeTheBricks();
                transform.Translate(Vector3.up * StairLaying.Instance.Count * Time.deltaTime);
                //Vector3.MoveTowards()
                //Vector3 setPosition = new Vector3(transform.position.x,
                //transform.position.y + Stack.Instance.Count, transform.position.z);
            }


            if (Input.GetMouseButtonUp(0) && _isClicked)
            {
                _isClicked = false;
                //Debug.Log("stairs child"+BrickLaying.Instance.stairs.transform.GetChild(0));
                StairLaying.Instance.DropTheLadder();
            }
        }
    }
}