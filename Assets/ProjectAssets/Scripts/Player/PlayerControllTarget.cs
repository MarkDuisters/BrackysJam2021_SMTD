using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerControllTarget : MonoBehaviour, Icell, IDamagable
{
    [SerializeField] GameObject mainParent;
    [Header ("Controller settings")]

    [SerializeField] float currentSpeed;
    [SerializeField] float speed;
    [SerializeField] float sprint;
    Vector3 moveDir;
    Vector3 lookDir;
    Rigidbody rb;
    [SerializeField] Camera cam;

    [Header ("Idamagable interface")]

    [SerializeField] float setHP = 100;
    public int hp { get; set; }

    public int dmg { get; set; }

    public enum CellType { Bacteria, WhiteBloodCell, Controller }

    [Header ("Icell interface")]
    [SerializeField] CellType setCellType = CellType.Bacteria;
    public byte cellType { get; set; }

    #region 
    public int splitAmount { get; set; }
    public float energy { get; set; }
    public float energyDrain { get; set; }
    public AudioSource playSplitSound { get; set; }
    public AudioClip[] splitSound { get; set; }
    #endregion

    float timer = 0;
    [SerializeField] float reveiveDmgInterval = 0.2f;
    void Start ()
    {
        rb = GetComponent<Rigidbody> ();

        if (cam == null)
        {
            cam = Camera.main;
        }

    }

    void Update ()
    {
        currentSpeed = Input.GetButton ("Dash") ? speed * sprint : speed;
        Vector3 forward = cam.transform.forward * Input.GetAxis ("Vertical") * currentSpeed;
        Vector3 right = cam.transform.right * Input.GetAxis ("Horizontal") * currentSpeed;

        moveDir = forward + right;
        // moveDir = new Vector3 (moveDir.x, rb.velocity.y, moveDir.z);
        lookDir = cam.transform.forward;

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
        Camera.main.GetComponent<AudioListener>().enabled = true;
       // Destroy (mainParent);
       mainParent.SetActive(false);
    }

    //empty functions, they do nothing but the interface will give a bitchfit if they are not here.
    #region 
    public void Split () { }
    public void DrainEnergy () { }

    #endregion

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
            if (getIcell.cellType == (byte) CellType.WhiteBloodCell)
            {
                timer += Time.deltaTime;
                if (timer >= reveiveDmgInterval)
                {
                    timer = 0;
                    ApplyDamage (getIdamagable.dmg);
                    print (hp);
                } //                print ("I dealt damage to-" + col.name);
            }

        }

    }
}