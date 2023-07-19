using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public UnityEvent OnGunShoot;

    public float coice;

    [SerializeField] public GameObject targetToCopy;

    public float delayBetweenShoots = 0.1f;

    private double getTriggerTime = 0f, delayed = 0f;
    private bool shoot = false;

    public AudioSource audios;
    public AudioClip shoots;

    ////////////////////////
    private CharacterController controller;
    private Vector3 playerVelocity;
    //private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    //private float jumpHeight = 1.0f;
    //private float gravityValue = -9.81f;
    ////////////////////////
    float coice_local = 0;
    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();

        //controller = targetToCopy.GetComponent<CharacterController>();
        //Debug.Log(controller);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = targetToCopy.transform.rotation;
        //Debug.Log(targetToCopy.transform.eulerAngles.y);
        getTriggerTime = Time.timeAsDouble;
        if(!shoot && Input.GetButton("Fire1"))
        {
            OnGunShoot.Invoke();
            //Debug.Log(targetToCopy.transform.rotation.y * 180);
            shoot = true;
            delayed = getTriggerTime;
            audios.PlayOneShot(shoots, 1);
            //targetToCopy.transform.rotation.x += Random.Range(-1.0f, 1.0f);
            //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //controller.Move(move * Time.deltaTime * playerSpeed);
            //controller.Move(playerVelocity * Time.deltaTime);
            coice_local = Random.Range(-1, 2);
            while (coice_local == 0)
            {
                coice_local = Random.Range(-1, 2);
            }
            targetToCopy.transform.rotation = Quaternion.Euler(
                targetToCopy.transform.eulerAngles.x,
                targetToCopy.transform.eulerAngles.y + coice / 2 * coice_local,
                0);

        }
        if (getTriggerTime - delayed > delayBetweenShoots)
        {
            shoot = false;
        }
    }
}
