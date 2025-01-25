using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMoviment : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
        Move(GameObject.FindGameObjectWithTag("Player"));
    }

    private void Move(GameObject bee)
    {
        if(Vector2.Distance(gameObject.transform.position, bee.transform.position) < 10)
        {
            agent.speed = moveSpeed;
            agent.destination = bee.transform.position; 
        }
    }
}
