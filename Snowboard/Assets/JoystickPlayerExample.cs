using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JoystickPlayerExample : MonoBehaviour
{
    public float forwardSpeed = 100;
    public float rightSpeed = 0;
    public float horizontalSpeed;

    public FloatingJoystick variableJoystick;
    public Rigidbody rb;
    public GameObject player;
    //public GameObject body;

    public static JoystickPlayerExample instance;

    private void Awake()
    {
        instance = this;
    }
    public void FixedUpdate()
    {
        if (GameManager.instance.tap)
        {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            //rb.AddForce(new Vector3(0, 0, 1) * forwardSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

            gameObject.transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * direction.x);



            /*if (direction.x == 0)
            {
                player.transform.DORotate(new Vector3(player.transform.position.x, 0, 0), 1);
            }

            else if (direction.x == -0.5f)
            {
                player.transform.DORotate(new Vector3(player.transform.position.x, 0, -15), 1);
            }

            else if (direction.x == 0.5f)
            {
                player.transform.DORotate(new Vector3(player.transform.position.x, 0, 15), 1);
            }*/
            
            //Debug.Log(direction);


            player.transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

            player.transform.Translate(Vector3.right * rightSpeed * Time.deltaTime);
        }
    }

}