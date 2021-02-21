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

        if (col.GetComponent<Icell> ().cellType == (byte) setCellType && col.GetComponent<Icell> ().cellType == (byte) CellType.Controller)
        {
            col.GetComponent<IDamagable> ().Kill ();
        }
    }
}