using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standings : MonoBehaviour
{
    public Transform player;
    public Transform rival1;
    public Transform rival2;
    public Transform rival3;
    public Transform rival4;
    public Transform rival5;
    public Transform rival6;
    public Transform rival7;

    public int order = 8;

    public bool ctrl1 = true;
    public bool ctrl2 = true;
    public bool ctrl3 = true;
    public bool ctrl4 = true;
    public bool ctrl5 = true;
    public bool ctrl6 = true;
    public bool ctrl7 = true;

    public static Standings instance;
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
        if(player.position.z > rival1.position.z)
        {
            
            if (ctrl1)
            {
                order--;
                ctrl1 = false;
            }
        }

        if (player.position.z > rival2.position.z)
        {
            if (ctrl2)
            {
                order--;
                ctrl2 = false;
            }
        }

        if (player.position.z > rival3.position.z)
        {
            if (ctrl3)
            {
                order--;
                ctrl3 = false;
            }
        }

        if (player.position.z > rival4.position.z)
        {
            if (ctrl4)
            {
                order--;
                ctrl4 = false;
            }
        }

        if (player.position.z > rival5.position.z)
        {
            if (ctrl5)
            {
                order--;
                ctrl5 = false;
            }
        }

        if (player.position.z > rival6.position.z)
        {
            if (ctrl6)
            {
                order--;
                ctrl6 = false;
            }
        }

        if (player.position.z > rival7.position.z)
        {
            if (ctrl7)
            {
                order--;
                ctrl7 = false;
            }
        }

        //Debug.Log(order);
    }
}
