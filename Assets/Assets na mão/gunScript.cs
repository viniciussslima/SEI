using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public UnityEvent OnGunShoot;

    public GameObject targetToCopy;
    public float delayBetweenShoots = 0.1f;

    private double getTriggerTime = 0f, delayed = 0f;
    private bool shoot = false;

    public AudioSource audios;
    public AudioClip shoots;

    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = targetToCopy.transform.rotation;

        getTriggerTime = Time.timeAsDouble;
        if(!shoot && Input.GetButton("Fire1"))
        {
            OnGunShoot.Invoke();
            Debug.Log("Atirei");
            shoot = true;
            delayed = getTriggerTime;
            audios.PlayOneShot(shoots, 1);
        }
        if (getTriggerTime - delayed > delayBetweenShoots)
        {
            shoot = false;
        }
    }
}
