using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    public FishStates currentState;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        currentState = FishStates.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState(currentState);
    }

    public void ChangeState(FishStates states)
    {
        switch (states)
        {
            case FishStates.Idle:
                Idle();
                break;
            case FishStates.Chase:
                Chase();
                break;
            case FishStates.Die:
                Die();
                break;
            default:
                Idle();
                break;
        }
    }

    void Idle()
    {
        Debug.Log("Idle");
    }
    void Chase()
    {
        Debug.Log("Chase");
    }
    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Die");
    }
    private void OnTriggerEnter(Collider other)
    {
        ChangeState(FishStates.Die);
        if (other.gameObject.tag == "Hook")
        {
            Debug.Log("Fish");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
