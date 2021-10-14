using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{

    public static Player instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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

        /*if (other.gameObject.CompareTag("Slope"))
        {
            JoystickPlayerExample.instance.forwardSpeed = ;
        }*/

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            GameManager.instance.coinCount++;
        }

        if (other.gameObject.CompareTag("EndPoint"))
        {
            StartCoroutine(GameManager.instance.Win());
        }

        if (other.gameObject.CompareTag("Boost"))
        {
            if(GetComponent<JoystickPlayerExample>().forwardSpeed > 40)
                GetComponent<JoystickPlayerExample>().forwardSpeed += 20;
            //StartCoroutine(SpeedDelay());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rival"))
        {
            GetComponent<JoystickPlayerExample>().forwardSpeed -= 10;
        }
    }

    public IEnumerator RotateDelay()
    {
        yield return new WaitForSeconds(1);

        gameObject.transform.DORotate(new Vector3(25, 0, 0), 1);
    }

    public IEnumerator ExitDelay()
    {
        yield return new WaitForSeconds(1);

        gameObject.transform.DORotate(new Vector3(0, 0, 0), 1);
    }

    public IEnumerator SpeedDelay()
    {
        yield return new WaitForSeconds(2);

        GetComponent<JoystickPlayerExample>().forwardSpeed = 100;
    }
}
