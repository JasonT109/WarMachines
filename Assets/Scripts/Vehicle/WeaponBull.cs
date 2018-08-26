using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

namespace WarMachines
{
    public class WeaponBull : MonoBehaviour
    {
        public int playerId = 0;
        public float MaxAngle = -135;
        public float FireVelocity = 100;
        public float FireForce = 15;
        public float ResetVelocity = 30;
        public float ResetForce = 5;
        public float ResetTime = 3;
        public Transform Pivot;
        public bool Active = true;

        private float CurrentForce;
        private float CurrentVelocity;
        private bool Firing = false;
        private bool Reseting = false;
        private Player player;

        public HingeJoint weaponHinge;
        public JointMotor weaponMotor;

        public void FireWeapon()
        {
            if(weaponHinge)
            {
                weaponMotor = weaponHinge.motor;

                if (!Firing && !Reseting)
                {
                    Firing = true;
                    CurrentForce = FireForce;
                    CurrentVelocity = FireVelocity;
                    StartCoroutine(ResetWait());
                }
            }
        }

        public void Awake()
        {
            player = ReInput.players.GetPlayer(playerId);
        }

        void Start()
        {
            SimpleCarController[] PlayerControllers = gameObject.GetComponentsInParent<SimpleCarController>();
            Rigidbody RB = gameObject.GetComponentInParent<Rigidbody>();
            weaponHinge.connectedBody = RB;
            weaponHinge.useMotor = true;
            weaponMotor = weaponHinge.motor;

            CurrentForce = ResetForce;
            CurrentVelocity = ResetVelocity;

            if (PlayerControllers.Length > 0)
            {
                playerId = PlayerControllers[0].playerId;
                player = ReInput.players.GetPlayer(playerId);
            }
        }

        void Update ()
        {
            if (player.GetButtonDown("AButton"))
                FireWeapon();
        }

        void FixedUpdate ()
        {
            if (weaponHinge)
            {
                weaponMotor = weaponHinge.motor;
                weaponMotor.targetVelocity = CurrentVelocity;
                weaponMotor.force = CurrentForce;
                weaponHinge.motor = weaponMotor;
            }
        }

        IEnumerator ResetWait()
        {
            yield return new WaitForSeconds(ResetTime);
            Reseting = true;
            Firing = false;
            CurrentForce = ResetForce;
            CurrentVelocity = ResetVelocity;
            StartCoroutine(FireWait());
        }

        IEnumerator FireWait()
        {
            yield return new WaitForSeconds(1);
            Reseting = false;
        }
    }
}
