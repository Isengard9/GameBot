using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    private float timer = 0;
    private float angle = 0;
    public float speed = 0.5f;
    public float radius = 10;

    private Vector3 rotationAngles;
    private float rotationSpeed;

    public GameObject Center;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        moveCircle();
    }

    void moveCircle()
    {
        timer += (Time.deltaTime) * speed;
        angle = timer;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3((Center.transform.position.x + Mathf.Sin(angle) * radius), 
                        Center.transform.position.y, ((Center.transform.position.z + Mathf.Cos(angle) * radius))), 0.35f);

        transform.Rotate(new Vector3(rotationAngles.x * rotationSpeed * Time.deltaTime, 
                        rotationAngles.y * rotationSpeed * Time.deltaTime, rotationAngles.z * rotationSpeed * Time.deltaTime));
    }
}
