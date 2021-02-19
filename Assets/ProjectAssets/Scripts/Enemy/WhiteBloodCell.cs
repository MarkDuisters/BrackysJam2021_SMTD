using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodCell : MonoBehaviour, Icell, IDamagable
{
   // [Header ("IDamagable interface")]
    public int hp { get; set; }
    public int dmg { get; set; }

   // [Header ("Icell interface")]
    public byte cellType { get; set; }
    //public GameObject masterCell { get; set; }
    public float energy { get; set; }
    public float energyDrain { get; set; }

    public int splitAmount { get; set; }
    public AudioSource playSplitSound { get; set; }
    public AudioClip[] splitSound { get; set; }

    public void Split ()
    {

    }
    public void DrainEnergy ()
    {

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

}