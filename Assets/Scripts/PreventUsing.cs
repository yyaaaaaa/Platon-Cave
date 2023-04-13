using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventUsing : MonoBehaviour
{
    
    [SerializeField] private List<string> requivednames;
    [SerializeField] private List<string> destroyed;
    
        private void OnEnable()
        {
        destroyed = CeepDestroying.GetObjs();
        }

    private void Update()
    {
        if (destroyed.ToArray().Length >= 1)
        {
            for (int i = 0; i < destroyed.ToArray().Length; i++)
            {
                for (int j = 0; j < requivednames.ToArray().Length; j++)
                {
                    if (destroyed[i].Equals(requivednames[j]))
                    {
                        GetComponent<CapsuleCollider2D>().enabled = true;
                        Destroy(GetComponent<PreventUsing>());
                    }
                }
               
            }
        }
       
    }
}
