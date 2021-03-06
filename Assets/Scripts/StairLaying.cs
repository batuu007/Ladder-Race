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
            //Invoke("LadderSpawnner",0.5f);
            LadderSpawnner();
            Stack.Instance.Deleted(lastChildIndex);
        }
    }

    private void LadderSpawnner()
    {
        var laddergo = Instantiate(ladder,
            new Vector3(stairs.transform.position.x, stairs.transform.position.y + scalingUp,
                stairs.transform.position.z + scalingUp), Quaternion.Euler(0, 90, 45));
        //System.Threading.Thread.Sleep(50);
        var ladders = laddergo.GetComponent<Ladder>();
        laddergo.transform.SetParent(stairs.transform);
        ladders.owner = this;
        _list.Add(ladders);
        scalingUp -= 0.211485f;
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
}