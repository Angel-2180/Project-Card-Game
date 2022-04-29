using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sellObjList : MonoBehaviour
{
    public static sellObjList current;

    public List<sellObject> objList;
    public List<sellObject> cpyobjList;

    private void Awake()
    {
        foreach (sellObject obj in objList)
        {
            cpyobjList.Add(obj);
        }
        current = this;
    }
}