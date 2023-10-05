using UnityEngine;

public class carMover : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.0f;
    public bool start = false;

    private float startTime;
    private float journeyLength;

    public float distCovered;
    public float fracJourney;


    void Start()
    {
        startTime = Time.time;
        journeyLength = 8;
        distCovered = 0;
        fracJourney = 0;
    }

    void Update()
    {
        if (start && endPoint != null)
        {

            Vector3 direction = (endPoint.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;

            distCovered = (Time.time - startTime) * speed;
            fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, fracJourney);

            if (fracJourney >= 1.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
