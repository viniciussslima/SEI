using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dano : MonoBehaviour
{
    public float Damage;
    public float BulletRange;
    private Transform PlayerCamera;

    void Start()
    {
        PlayerCamera = Camera.main.transform;
    }

    // Update is called once per frame
    public void Shoot()
    {
        Debug.Log("Shoot");

        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
        if(Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
            Debug.Log("gunRay");

            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                Debug.Log("collider");

                enemy.Health -= Damage;
            }
        }
    }
}
