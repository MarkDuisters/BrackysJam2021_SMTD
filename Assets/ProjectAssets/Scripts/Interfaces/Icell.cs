using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Each class having this interface must implement the following variables and functions.
public interface Icell
{

    public byte cellType { get; set; }
    //public GameObject masterCell { get; set; }
    public float energy { get; set; }
    public float energyDrain { get; set; }
    public Transform followTarget { get; set; }
    public int splitAmount { get; set; }
    public AudioSource playSplitSound { get; set; }
    public AudioClip[] splitSound { get; set; }

    public void Split ();
    public void DrainEnergy ();

}