using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public GameObject markerEffect;
    private GameObject last;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var markCount = GameObject.FindGameObjectsWithTag("Marker");
                if (hit.collider.tag == "Road")
                {
                    if (markCount.Length == 3) { Destroy(markCount[1]); }

                    ParticleSystem.MainModule settings = markerEffect.GetComponent<ParticleSystem>().main;
                    if (settings.startColor.color == Color.red)
                    {
                        settings.startColor = Color.green;
                    }
                    else
                        settings.startColor = Color.red;
                    last = Instantiate(markerEffect, hit.point, Quaternion.identity);
                    if (last) Destroy(last, 2);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var markCount = GameObject.FindGameObjectsWithTag("Marker");
                if (hit.collider.tag == "Road")
                {
                    if (markCount.Length == 3) { Destroy(markCount[1]); }
                        
                    ParticleSystem.MainModule settings = markerEffect.GetComponent<ParticleSystem>().main;
                    if (settings.startColor.color == Color.red)
                    {
                        settings.startColor = Color.green;
                    }
                    else
                        settings.startColor = Color.red;
                    last =  Instantiate(markerEffect, hit.point, Quaternion.identity);
                    if (last) Destroy(last,2);
                }
            }
        }
    }
}