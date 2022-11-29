using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 20f;

    [SerializeField]
    private float translationSpeed = 5f;

    private void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * translationSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * translationSpeed);
        }
    }
}
