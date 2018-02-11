using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : BaseSkill
{
    public GameObject Projectile;
    public GameObject Player;
    public GameObject PlayerWeapon;
    override public void preCast()
    {
        PlayerWeapon = GameObject.Find("Player/ProjectilePoint");
        Instantiate(Projectile,PlayerWeapon.transform.position,PlayerWeapon.transform.rotation);
        Projectile.GetComponent<ChasingProjectile>().origin = this.origin;
        Projectile.GetComponent<ChasingProjectile>().target = this.target;

    }
    override public void Casting() { }
    override public void postCast()
    {
    }
}
