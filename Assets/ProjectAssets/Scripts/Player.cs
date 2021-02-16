using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
[RequireComponent (typeof (Rigidbody))]
public class Player : MonoBehaviour, Icell, IDamagable
{

    [SerializeField] private byte setCellType = 0;
    public byte cellType { get; set; }
   // public GameObject masterCell { get; set; }

    [SerializeField] private int setHP = 1;
    public int hp { get; set; }

    [SerializeField] private int setDmg = 1;
    public int dmg { get; set; }

    [SerializeField] private bool setAlive;
    public bool alive { get; set; }

    [SerializeField] private int setSplitAmount = 2;
    public int splitAmount { get; set; }

    public AudioSource playSplitSound { get; set; }

    [SerializeField] private AudioClip[] setSplitSound;
    public AudioClip[] splitSound { get; set; }

    void Start ()
    {
        cellType = setCellType;
        hp = setHP;
        dmg = setDmg;
        alive = setAlive;
        playSplitSound = GetComponent<AudioSource> ();
        splitAmount = setSplitAmount;
        splitSound = setSplitSound;

        print ($"test:-hp:{hp},-alive:{alive},-dmg:{dmg}");
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
            playSplitSound.PlayOneShot (splitSound[Random.Range (0, splitSound.Length - 1)]);
            print ("I cloned myself!");
        }

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
                print ("I dealt damage to-");
            }

        }

    }
}