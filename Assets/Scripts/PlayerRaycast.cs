using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            RaycastHit result;
            bool thisWasHit = Physics.Raycast(transform.position, transform.forward, out result, Mathf.Infinity);

            Vector3 start = transform.position;
            Vector3 end = transform.position + transform.forward * 50f;
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);
            
            //remove debug.drawray when using line renderer
            //Debug.DrawRay(transform.position, transform.forward * 50f, Color.yellow, 0.05f);

            if (thisWasHit)
            { 
                result.collider.gameObject.GetComponent<MeshRenderer>().material.color = GetRandomColor();
               // Destroy(result.collider.gameObject);
            }
        }
    }

    private Color GetRandomColor()
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        return color;
    }
}
