using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

public class StairLaying : Singleton<StairLaying>
{
    [SerializeField, ReadOnly] private List<Ladder> _list = new List<Ladder>();
    [SerializeField] public GameObject stairs;
    [SerializeField] public GameObject ladder;
    [SerializeField] public float scalingUp = 0;

    public int Count => _list.Count;

    //private bool _isEntered = true;

    public void KneeTheBricks()
    {
        int lastChildIndex = Stack.Instance.stackPoint.transform.childCount - 1;
        //Vector3 setPosition = new Vector3(stickman.transform.position.x, stickman.transform.position.y + scalingUp,
        //stickman.transform.position.z + scalingUp);

        if (Stack.Instance.stackPoint.transform.GetChild(lastChildIndex) != null)
        {
            //_isEntered = true;
            Debug.Log(lastChildIndex);
            //yield return new WaitForSeconds(0.01f);
            var laddergo = Instantiate(ladder,
                new Vector3(stairs.transform.position.x, stairs.transform.position.y + scalingUp,
                    stairs.transform.position.z + scalingUp), Quaternion.Euler(0, 90, 45));
            var ladders = laddergo.GetComponent<Ladder>();
            laddergo.transform.SetParent(stairs.transform);
            ladders.owner = this;
            _list.Add(ladders);
            scalingUp += 0.211485f;
            Stack.Instance.Deleted(lastChildIndex);
            //Stack.Instance.currentStack--
            //Destroy(Stack.Instance.stackPoint.transform.GetChild(lastChildIndex).gameObject);

            //Stack.Instance.stackPoint.transform.GetChild(lastChildIndex).position = setPosition;
            /*var brickgo = stairs.transform.GetChild(0).GetComponent<Brick>();
            var brick = brickgo.owner;
            var count = brick.Count;
            Stack.Instance.Deleted(count-1);*/
            //Stack.Instance.stackPoint.transform.GetChild(lastChildIndex).SetParent(stairs.transform);
        }
    }

    public void DropTheLadder()
    {
        int lastChildIndex = stairs.transform.childCount - 1;
        stairs.transform.DetachChildren();
        Deleted(lastChildIndex);
        scalingUp = 0;
    }
    public void Deleted(int index)
    {
        if (index < _list.Count)
        {
            _list.RemoveAt(index);
        }
    }

    public void Deleted(Ladder ladder)
    {
        var index = _list.IndexOf(ladder);
        if (index != -1)
        {
            Deleted(index);
        }
    }
}