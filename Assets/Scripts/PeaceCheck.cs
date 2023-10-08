using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaceCheck : MonoBehaviour
{
    public static bool isPeaceful = false;
    public static int WhoTalks;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name=="HalimeTeyze")
        {
            WhoTalks=0;
        }

        else if(other.gameObject.name == "AzizeTeyze")
        {
            WhoTalks = 1;
        }
        else if (other.gameObject.name == "SevkiDede")
        {
            WhoTalks = 2;
        }

        else if (other.gameObject.name == "Biz")
        {
            WhoTalks = 3;
        }
    }
}
