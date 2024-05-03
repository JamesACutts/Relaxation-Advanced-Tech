using UnityEngine;

public class BirdAI : MonoBehaviour
{
    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    public float perchingTimeMin = 2f;
    public float perchingTimeMax = 5f;
    public Transform[] waypoints; // Waypoints for flying paths

    private Transform currentTarget;
    private float perchingTimer;
    private bool isPerching;

    void Start()
    {
        // Initialize the bird's initial target
        SetRandomTarget();
    }

    void Update()
    {
        if (!isPerching)
        {
            // Move towards the current target
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * Random.Range(minSpeed, maxSpeed));

            // Rotate towards the current target
            transform.LookAt(currentTarget);

            // Check if the bird has reached its current target
            if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
            {
                // Start perching
                isPerching = true;
                perchingTimer = Random.Range(perchingTimeMin, perchingTimeMax);
            }
        }
        else
        {
            // Bird is perching, count down the timer
            perchingTimer -= Time.deltaTime;
            if (perchingTimer <= 0f)
            {
                // Perching time is over, resume flying
                isPerching = false;
                SetRandomTarget();
            }
        }
    }

    void SetRandomTarget()
    {
        // Choose a random waypoint as the next target
        currentTarget = waypoints[Random.Range(0, waypoints.Length)];
    }
}
