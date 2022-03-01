using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : Singleton<Stack>
{
    [SerializeField, ReadOnly] private List<Brick> _list = new List<Brick>();

    //[SerializeField] public int currentStack = 0;
    [SerializeField] public GameObject stackPoint;
    [SerializeField] public float scalingUp = 0;

    public int Count => _list.Count;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            AddObjToPoint(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void AddObjToPoint(GameObject obj)
    {
        Vector3 setPos = new Vector3(stackPoint.transform.position.x, stackPoint.transform.position.y,
            stackPoint.transform.position.z);
        if (_list.Count%3==0 )
        {
            //setPos.y += scalingUp;
            setPos.z += 0f; 
            setPos.y += scalingUp;
        } 
        if (_list.Count%3==1 )
        {
            //setPos.y += scalingUp;
            setPos.z -= 0.0533f;
            setPos.y += scalingUp;
        }

        if (_list.Count%3==2)
        {
            //setPos.y += scalingUp;
            setPos.z -= 0.1f;
            setPos.y += scalingUp;
        }
        Debug.Log("kacıncı elaman : "+ _list.Count%3);
        //index++;
        var brickgo = Instantiate(obj, setPos
            , Quaternion.Euler(0, 0, 90));
        var brick = brickgo.GetComponent<Brick>();
        brickgo.transform.SetParent(stackPoint.transform);
        brickgo.GetComponent<CapsuleCollider>().isTrigger = false;
        brick.owner = this;
        _list.Add(brick);
        scalingUp += 0.02f;
    }

    public void Deleted(int index)
    {
        if (index < _list.Count)
        {
            var brick = _list[index];
            _list.RemoveAt(index);
            Destroy(brick.gameObject);
            scalingUp -= 0.02f;
        }
    }

    public void Deleted(Brick brick)
    {
        var index = _list.IndexOf(brick);
        if (index != -1)
        {
            Deleted(index);
        }
    }
}