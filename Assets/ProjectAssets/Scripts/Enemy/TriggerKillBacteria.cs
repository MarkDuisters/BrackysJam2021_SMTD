using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKillBacteria : MonoBehaviour
{

    public enum CellType { Bacteria, WhiteBloodCell, Controller }

    [Header ("Icell interface")]
    [SerializeField] CellType setCellType = CellType.Bacteria;

    // Update is called once per frame
    void OnTriggerEnter (Collider col)
    {

        Icell cell = col.GetComponent<Icell> ();
        if (cell.cellType == (byte) setCellType)
        {
            cell.followTarget = col.transform;
        }
    }
}