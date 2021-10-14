using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rival : MonoBehaviour
{
    public float forwardSpeed;

    public static Rival instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GameManager.instance.tap)
        {
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedTrigger"))
        {
            //JoystickPlayerExample.instance.forwardSpeed = 75;
            StartCoroutine(RotateDelay());
        }

        if (other.gameObject.CompareTag("ExitTrigger"))
        {
            //JoystickPlayerExample.instance.forwardSpeed = 75;
            StartCoroutine(ExitDelay());
        }

    }

    public IEnumerator RotateDelay()
    {
        yield return new WaitForSeconds(1);

        gameObject.transform.DORotate(new Vector3(25, 0, 0), 1);

        //gameObject.transform.eulerAngles = new Vector3(25, 0, 0);
    }

    public IEnumerator ExitDelay()
    {
        yield return new WaitForSeconds(2);

        gameObject.transform.DORotate(new Vector3(0, 0, 0), 1);

        //gameObject.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}
