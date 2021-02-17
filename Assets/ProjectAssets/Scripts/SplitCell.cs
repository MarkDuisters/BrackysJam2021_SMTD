using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCell : MonoBehaviour
{

    public int cellType = 0;
    public int resource = 10;
    // Update is called once per frame
    void OnTriggerEnter (Collider col)
    {
        Icell getIcell = col.GetComponent<Icell> ();
        if (getIcell != null && getIcell.cellType == cellType && resource > 0)
        {
            getIcell.Split ();
            resource--;
        }
        else
        {
            gameObject.SetActive (false);

        }
    }
}