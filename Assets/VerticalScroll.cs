using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [SerializeField] float waterMovementSpeed = 1f;

    private void Update()
    {
        transform.position += new Vector3 (0, waterMovementSpeed * Time.deltaTime, 0);
       
    }
}
