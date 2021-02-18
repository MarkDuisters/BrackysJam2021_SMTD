using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
[RequireComponent (typeof (Rigidbody))]
public class PlayerCell : MonoBehaviour, Icell, IDamagable
{
    [Header ("Movement")]
    [SerializeField] float currentSpeed;
    [SerializeField] float speed = 1;
    [SerializeField] float dash = 2;
    Vector3 moveDir;
    Vector3 lookDir;

    Rigidbody rb;

    [SerializeField] Transform followTarget;
    [SerializeField] float followThreshold = 1f;

    [Header ("IDamagable interface")]

    [SerializeField] private int setHP = 1;
    public int hp { get; set; }

    [SerializeField] private int setDmg = 1;
    public int dmg { get; set; }

    [Header ("Icell interface")]
    [SerializeField] private byte setCellType = 0;
    public byte cellType { get; set; }
    // public GameObject masterCell { get; set; }

    [SerializeField] private int setSplitAmount = 2;
    public int splitAmount { get; set; }

    [SerializeField] private int setEnergy = 1;
    public int energy { get; set; }

    public AudioSource playSplitSound { get; set; }

    [SerializeField] private AudioClip[] setSplitSound;
    public AudioClip[] splitSound { get; set; }

    void Start ()
    {
        cellType = setCellType;
        hp = setHP;
        dmg = setDmg;
        playSplitSound = GetComponent<AudioSource> ();
        splitAmount = setSplitAmount;
        energy = setEnergy;
        splitSound = setSplitSound;
        rb = GetComponent<Rigidbody> ();
    }

    void Update ()
    {

        currentSpeed = Input.GetButton ("Dash") ? speed * dash : speed;
        Vector3 forward = new Vector3 ();
        float distance = Vector3.Distance (transform.position, followTarget.position);
        if (distance >= followThreshold)
        {
            forward = transform.forward * distance * currentSpeed;
        }

        lookDir = followTarget.position - transform.position;

        moveDir = forward;
        //   moveDir = new Vector3 (moveDir.x, rb.velocity.y, moveDir.z);

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
            Destroy (gameObject);
        }
    }

    public void Split ()
    {
        for (int i = 0; i < splitAmount; i++)
        {
            GameObject clone = Instantiate (gameObject);

            if (clone.GetComponent<Icell> ().playSplitSound == null)
            {
                clone.GetComponent<Icell> ().playSplitSound = clone.GetComponent<AudioSource> ();
            }
            clone.GetComponent<Icell> ().playSplitSound.PlayOneShot (splitSound[Random.Range (0, splitSound.Length - 1)]);
            //            print ("I cloned myself!");
        }

        Destroy (gameObject);

    }

    public void DrainEnergy ()
    {

    }

    public void OnTriggerEnter (Collider col)
    {
        IDamagable getIdamagable = col.GetComponent<IDamagable> ();
        Icell getIcell = col.GetComponent<Icell> ();

        //only deal damage to a damagable object if it is not part of our celltype
        if (getIdamagable != null && getIcell != null)
        {
            if (getIcell.cellType != cellType)
            {
                getIdamagable.ApplyDamage (dmg);
                print ("I dealt damage to-" + col.name);
            }

        }

    }
}