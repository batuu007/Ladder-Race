using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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
                StairLaying.Instance.KneeTheBricks();
                transform.DOMoveY(3 + 0.211485f, 0.5f);
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