using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCell : MonoBehaviour
{

    public enum CellType { Bacteria, WhiteBloodCell, Controller }

    [SerializeField] CellType setCellType = CellType.Bacteria;
    byte cellType;

    public int resource = 2;
    [SerializeField] GameObject creature;

    // Update is called once per frame
    void OnTriggerEnter (Collider col)
    {

        Icell getIcell = col.GetComponent<Icell> ();
        cellType = (byte) setCellType;
        if (getIcell != null && getIcell.cellType == cellType && resource > 0 && GameManager.instance.creatureCount < GameManager.instance.maxCreatures)
        {
            getIcell.Split ();
            resource--;
        }

        else if (GameManager.instance.creatureCount <= 0 && getIcell != null && getIcell.cellType == (byte) CellType.Controller)
        {
            GameObject go = Instantiate (creature);
            go.transform.position = col.transform.position;
            go.GetComponent<Icell> ().followTarget = col.transform;
            GameManager.instance.creatureCount++;
        }
        if (resource <= 0)
        {
            gameObject.SetActive (false);

        }
    }
}