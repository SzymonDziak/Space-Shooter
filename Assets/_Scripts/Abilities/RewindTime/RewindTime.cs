using System.Collections.Generic;
using UnityEngine;

public class RewindTime : MonoBehaviour
{
    [SerializeField]
    private bool isRewinding = false;

    LinkedList<pointInTime> pointsInTime;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pointsInTime = new LinkedList<pointInTime>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StopRewind();
           }
    }
    private void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }
    void Rewind()
    {
        if(pointsInTime.Count > 0)
        {
            pointInTime point = pointsInTime.First.Value;
            transform.position = point.position;
            transform.rotation = point.rotation;
            pointsInTime.RemoveFirst();
        }
        else
        {
            StopRewind();
        }
    }
    void Record()
    {
        // Debug.Log("Time passed" + 1f / Time.fixedDeltaTime);
        if (pointsInTime.Count > 1f / Time.fixedDeltaTime)
        {
            pointsInTime.RemoveLast();
        }
        pointsInTime.AddFirst(new pointInTime(transform.position, transform.rotation));
    }
    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }
    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
        if (gameObject.tag == "Hazard")
        {
            rb.velocity = transform.forward;
        }
    }
}