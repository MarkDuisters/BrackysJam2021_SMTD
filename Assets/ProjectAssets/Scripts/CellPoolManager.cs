using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPoolManager : MonoBehaviour
{

    public List<GameObject> inactivePool;
    public List<GameObject> activePool;

    public GameObject currentCell;

    static public CellPoolManager cellPool;

    void Awake ()
    {
        if (cellPool == null)
        {
            cellPool = this;
        }
        else
        {
            Destroy (gameObject);
        }
    }

    // Start is called before the first frame update
    public void AddToActivePool ()
    {
        if (inactivePool.Count > 0)
        {
            currentCell = inactivePool[0];
            currentCell.SetActive (true);
            activePool.Add (currentCell);
            inactivePool.Remove (currentCell);

        }
    }

    // Update is called once per frame
    public void AddToInActivePool ()
    {
        if (activePool.Count > 0)
        {
            GameObject obj = activePool[0];
            obj.SetActive (false);
            activePool.Remove (obj);
            inactivePool.Add (obj);

        }
    }
}