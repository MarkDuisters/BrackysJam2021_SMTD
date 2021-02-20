using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class WhiteBloodCell : MonoBehaviour, Icell, IDamagable
{

    [Header ("Movement")]
    float currentSpeed;
    [SerializeField] float speed = 1;
    Vector3 moveDir;
    Vector3 lookDir;

    Rigidbody rb;

    [SerializeField] Transform followTarget;
    [SerializeField] float followThreshold = 1f;

    [Header ("IDamagable interface")]
    [SerializeField] int setHP;
    public int hp { get; set; }

    [SerializeField] private int setDmg = 1;
    public int dmg { get; set; }

    public enum CellType { Bacteria, WhiteBloodCell,Controller }

    [Header ("Icell interface")]
    [SerializeField] CellType setCellType = CellType.WhiteBloodCell;
    public byte cellType { get; set; }

    [HideInInspector] public float energy { get; set; }

    [HideInInspector] public float energyDrain { get; set; }

    [HideInInspector] public int splitAmount { get; set; }

    [HideInInspector] public AudioSource playSplitSound { get; set; }

    [HideInInspector] public AudioClip[] splitSound { get; set; }

    void Start ()
    {
        hp = setHP;
        dmg = setDmg;
        cellType = (byte) setCellType;
        //        print (cellType);

        rb = GetComponent<Rigidbody> ();

    }

    //empty functions, they do nothing but the interface will give a bitchfit if they are not here.
    #region 
    public void Split ()
    {

    }
    public void DrainEnergy ()
    {

    }

    #endregion

    void Update ()
    {
        if (followTarget == null)
        {
            return;
        }

        currentSpeed = speed;
        Vector3 forward = new Vector3 ();
        float distance = Vector3.Distance (transform.position, followTarget.position);
        //  if (distance >= followThreshold)
        {
            forward = (transform.forward * currentSpeed) / (Mathf.Sqrt (distance));
        }
        forward = transform.forward * currentSpeed;
        lookDir = followTarget.position - transform.position;

        moveDir = forward;

    }

    void FixedUpdate ()
    {
        Movement ();

    }

    void Movement ()
    {

        //de berekende move en rotation vectoren worden hier in FixedUpdate toegepast.
        rb.rotation = Quaternion.LookRotation (lookDir);
        rb.velocity = moveDir;

    }

    public void ApplyDamage (int getDmg)
    {
        hp -= getDmg;

        if (hp <= 0)
        {
            Kill ();
        }
    }
    public void Kill ()
    {
        Destroy (gameObject);
    }

    public void OnTriggerStay (Collider col)
    {

        if (col.isTrigger == true)
        {
            return;
        }

        IDamagable getIdamagable = col.GetComponent<IDamagable> ();
        Icell getIcell = col.GetComponent<Icell> ();

        //only deal damage to a damagable object if it is not part of our celltype
        if (getIdamagable != null && getIcell != null)
        {

            if (getIcell.cellType != cellType)
            {
                followTarget = col.transform;

                //                print (followTarget);

                //   getIdamagable.ApplyDamage (dmg);
                //                print ("I dealt damage to-" + col.name);

            }

        }

    }
    /* public void OnTriggerExit ()
     {
         followTarget = null;
     }*/

}