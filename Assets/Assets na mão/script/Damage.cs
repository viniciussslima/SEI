using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dano : MonoBehaviour
{
    public float Damage;
    public float BulletRange;
    public TextMeshProUGUI lifeText;
    private Transform PlayerCamera;
    private float timeWhenDisappear;
    private float timeToAppear = 0.5f;


    void Start()
    {
        PlayerCamera = Camera.main.transform;
    }

    // Update is called once per frame
    public void Shoot()
    {
        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
        if(Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= Damage;
                lifeText.text = enemy.Health.ToString();
                timeWhenDisappear = Time.time + timeToAppear;
            }
        }
    }

    void Update()
    {
        if (Time.time >= timeWhenDisappear)
        {
            lifeText.text = "";
        }
    }
}
