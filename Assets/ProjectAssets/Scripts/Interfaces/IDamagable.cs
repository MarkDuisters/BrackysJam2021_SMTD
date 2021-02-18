using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{

    public int hp { get; set; }
    public int dmg { get; set; }

    public void ApplyDamage (int dmg);
    public void Kill ();

}