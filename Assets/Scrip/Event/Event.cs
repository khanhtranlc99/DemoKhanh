using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public static Event even;
    private void Awake()
    {
        even = this;
    }

   enum haha
    {
        end,
        start,
        pause
    }    

}
