using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private float StartingHealt;
    private float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;



            if (health <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        Health = StartingHealt;
    }
}
