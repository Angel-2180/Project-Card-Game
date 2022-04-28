using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sellObjList : MonoBehaviour
{
    public static sellObjList current;

    public List<sellObject> objList;

    private void Awake()
    {
        current = this;
    }
}