using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float Health = 50;
    public float DamageForceThreshold = 2;
    public bool IsWeapon = false;
    public float DamageMultiplier = 1;

    public GameObject HitVFX;

    private bool Wrecked = false;
    private Collider MyCollider;

    void OnCollisionEnter(Collision collision)
    {
        if (IsWeapon)
        {
            if (collision.relativeVelocity.magnitude > DamageForceThreshold)
            {
                Damage ColliderDamage = collision.collider.GetComponent<Damage>();
                if (ColliderDamage)
                {
                    Debug.Log(collision.collider + " has taken damage from a force " + (collision.relativeVelocity.magnitude * DamageMultiplier));
                    ColliderDamage.Health -= collision.relativeVelocity.magnitude * DamageMultiplier;
                }
                foreach (ContactPoint contact in collision.contacts)
                {
                    //instantiate effects
                    Quaternion Rot = Quaternion.FromToRotation(Vector3.forward, contact.normal);
                    GameObject NewHitVFX = Instantiate(HitVFX, contact.point, Rot);
                }
            }
        }
    }

    void Start()
    {
        MyCollider = gameObject.GetComponent<Collider>();
    }

    void Update ()
    {
        if (Health <= 0 && !Wrecked)
        {
            Wrecked = true;
            MyCollider.enabled = false;    
            Debug.Log(gameObject + " has been destroyed!");
        }
    }
}
