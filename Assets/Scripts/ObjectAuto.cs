using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAuto : Object
{
    public string reqvname;
    private new void Awake()
    {
        List<string> objs;
        objs = CeepDestroying.GetObjs();
        for (int i = 0; i < objs.ToArray().Length;i++)
        {
            if (objs[i] == reqvname)
            {
                CeepDestroying.AddToArray(this.name);
            }
        }
    }


}
