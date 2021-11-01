using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Casting : MonoBehaviour
{
    public GameObject snowPrefab;
    public Transform rightHand;
    public Transform snowPos;

    public GameObject snow;

    public float targetDistance;

    RaycastHit TheHit;

    private void Start()
    {
        snow = Instantiate(snowPrefab, snowPos.transform.position, snowPos.rotation, rightHand);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //RaycastHit TheHit;

        if(Physics.Raycast(new Vector3(transform.position.x,transform.position.y + 1, transform.position.z), transform.TransformDirection (transform.forward), out TheHit))
        {
            targetDistance = TheHit.distance;
        }

        Debug.DrawRay(TheHit.point, TheHit.normal, Color.red, 20, true);

        if (TheHit.collider.gameObject.CompareTag("Rival") && targetDistance < 80)
        {
            Time.timeScale = 0.3f;

            Debug.Log("ah kafam");
            TheHit.collider.gameObject.GetComponent<Animator>().SetBool("Falling", true);
            TheHit.collider.gameObject.GetComponent<Rival>().enabled = false;
            TheHit.collider.gameObject.tag = "Untagged";
            TheHit.collider.gameObject.transform.eulerAngles = new Vector3(0, 60, 0);

            StartCoroutine(SnowBallDelay());

            StartCoroutine(Player.instance.SnowBall());
        }

        else
        {
            Debug.Log("okay abim");
        }
    }

    public IEnumerator SnowBallDelay()
    {
        snow.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);

        snow.transform.parent = null;
        snow.transform.DOMove((TheHit.collider.gameObject.transform.position), 0.3f).SetEase(Ease.Linear);

        //yield return new WaitForSeconds(0.5f);
        //snow.transform.GetChild(0).gameObject.SetActive(false);

        snow = Instantiate(snowPrefab, snowPos.transform.position, snowPos.rotation, rightHand);
    }
}
