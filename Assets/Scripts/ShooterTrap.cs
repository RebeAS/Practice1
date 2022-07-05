using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTrap : MonoBehaviour
{
    public GameObject Projectile;
    public Transform ShootPoint;

    private bool isShooting = false;

    public float TimeToShoot;

    public enum ShootTypes
    {
        Active, ShootOne, RemainActive, Deactivated
    }

    public ShootTypes myShootTypes;

    private void Start()
    {
        if (myShootTypes == ShootTypes.Active)
        {
            StartCoroutine(ActiveShooter());
            isShooting = true;
        }
    }

    public IEnumerator ActiveShooter()
    {
        while (myShootTypes == ShootTypes.Active)
        {
            yield return new WaitForSeconds(TimeToShoot);
            ShootTrap();
        }
    }

    public void OnActivation()
    {
        switch (myShootTypes)
        {
            case ShootTypes.ShootOne:
                ShootTrap();
                break;

            case ShootTypes.RemainActive:
                if (!isShooting)
                {
                    isShooting = true;
                    StartCoroutine(ActiveShooter());
                }
                break;
        }
    }

    public void ShootTrap()
    {
        isShooting = true;
        Instantiate(Projectile, ShootPoint.position, ShootPoint.rotation);
    }

    public void StopShooter()
    {
        isShooting = false;
    }
}
