using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{

    NavMeshAgent agent;
    Animator animator;

    Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.updatePosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("speed", agent.velocity.magnitude);

        Vector3 WorldDeltaPosition = agent.nextPosition - transform.position;

        float deltaX = Vector3.Dot(transform.right, WorldDeltaPosition);
        float deltaY = Vector3.Dot(transform.forward, WorldDeltaPosition);

        Vector2 deltaPosition = new Vector2(deltaX, deltaY);

        velocity = deltaPosition / Time.deltaTime;

        bool shouldMove = velocity.magnitude > 0.25f && agent.remainingDistance > agent.radius;

        animator.SetBool("shouldMove", shouldMove);

        animator.SetFloat("velX", velocity.x);
        animator.SetFloat("velY", velocity.y);
    }

    private void OnAnimatorMove() {
        transform.position = agent.nextPosition;
    }
}
