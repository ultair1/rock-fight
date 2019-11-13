using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 posNex;

    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform childTransform;
    [SerializeField]
    private Transform transformB;
    // Start is called before the first frame update
    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        posNex = posB;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void ChangeDestination()
    {
        posNex = posNex != posA ? posA : posB;
    }
    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, posNex, speed * Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition,posNex) <= 0.1)
        {
            ChangeDestination();
        }
    }
}
