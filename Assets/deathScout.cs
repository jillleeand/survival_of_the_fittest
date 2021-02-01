using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class deathScout : MonoBehaviour
{
    private List<Transform> wp;
    private Transform replacement;
    public GameObject scoutPrefab;
    private GameObject oneTri;
    private string tagName;
    private CinemachineVirtualCamera camFollow;

    // Start is called before the first frame update
    void Start()
    {

        if (tag == "TScout")
        {
            tagName = "Triangles";
        }

        else
        {
            camFollow = GameObject.FindGameObjectWithTag("VCam").GetComponent<CinemachineVirtualCamera>();
            tagName = "Circles";
            camFollow.Follow = transform;
        }
        wp = GameObject.FindGameObjectWithTag(tagName).GetComponent<Waypoints>().waypoints;
        wp.Add(transform);

        GetComponent<lifeCircle>().foodStack.Clear();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Theton"))
        {
            Death();
        }

    }

    public void Death()
    {
        if (wp.Count > 1)
        {
            replacement = wp[Random.Range(0, wp.Count)];

            while ((replacement == false && wp.Count > 2) || replacement == gameObject.transform)
            {
                replacement = wp[Random.Range(0, wp.Count)];
            }

            if (replacement)
            {
                Instantiate(scoutPrefab, replacement.position, replacement.rotation);
                Destroy(replacement.gameObject);
                tag = "Untagged";

                if (tagName == "Triangles")
                {
                    oneTri = GameObject.FindGameObjectWithTag("Triangle");
                    oneTri.GetComponent<feedStack>().scoutChange();
                }

            }


        }
        Destroy(gameObject);
    }


}
