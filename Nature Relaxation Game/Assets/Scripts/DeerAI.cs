using UnityEngine;
using UnityEngine.AI;

public class DeerAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private Vector3 grazingPoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
 /*       animator = GetComponent<Animator>();*/

        // Set initial grazing point
        SetRandomGrazingPoint();
    }

    void Update()
    {
        // Check if the deer has reached its grazing point
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            // Set a new random grazing point
            SetRandomGrazingPoint();
        }
    }

    void SetRandomGrazingPoint()
    {
        // Generate a random point within a predefined grazing area
        grazingPoint = new Vector3(Random.Range(-50f, 50f), 0f, Random.Range(-50f, 50f));
        grazingPoint += transform.position;

        // Set the grazing point for the NavMeshAgent
        agent.SetDestination(grazingPoint);

        // Update animator parameters or other behavior based on the new destination
/*        animator.SetBool("Walking", true);*/
    }

    // Implement other behaviors such as reacting to threats and fleeing
}
