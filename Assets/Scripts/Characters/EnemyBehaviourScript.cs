using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBehaviourScript : MonoBehaviour {
    private NavMeshAgent agent;
    [SerializeField] private Transform targetTransform;
    enum EnemyState { Idle, Patrol, Chase, Attack, Stun, Dead };
    [SerializeField] EnemyState state;
    private int pathIndex = 0;
    [Header("Path")]
    public Transform[] points;

    [Header("Timers")]
    public float idleTime = 1;
    public float stunTime = 1;
    public float coolDownAttack = 0.3f;
    private float timeCounter = 0;

    [Header("Distances")]
    public float chaseRange;
    public float attackRange;
    [SerializeField] private float distanceFromTarget;

    [Header("Booleans")]
    private bool canAttack = false;

    [Header("Properties")]
    public int damage = 10;
    public int life = 30;

    public Animator anim;

    public AudioSource deadSound;



    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();

        //targetTransform = GameObject.Find("Player").transform;
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;

        SetIdle();
	}
	
    void OnEnable()
    {
        
        life = 30;
        SetIdle();
        agent.Stop();
    }

	void Update ()
    {
        //agent.SetDestination(targetTransform.position);
        CalculateDistanceFromTarget();
        switch(state)
        {
            case EnemyState.Idle:
                IdleUpdate();
                break;
            case EnemyState.Patrol:
                PatrolUpdate();
                break;
            case EnemyState.Chase:
                ChaseUpdate();
                break;
            case EnemyState.Attack:
                AttackUpdate();
                break;
            case EnemyState.Stun:
                StunUpdate();
                break;
            case EnemyState.Dead:
                DeadUpdate();
                break;
        }

	}

    #region Updates
    void IdleUpdate()
    {
        if (timeCounter >= idleTime)
        {
            SetPatrol();
        }
        else timeCounter += Time.deltaTime;
    }
    void PatrolUpdate()
    {
        if(distanceFromTarget < chaseRange)
        {
            SetChase();
            return;
        }
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            pathIndex++;
            if (pathIndex >= points.Length) pathIndex = 0;

            SetPatrol();
        }
    }
    void ChaseUpdate()
    {
        agent.SetDestination(targetTransform.position);

        if(distanceFromTarget > chaseRange)
        {
            SetPatrol();
            return;
        }

        if(distanceFromTarget < attackRange)
        {
            SetAttack();
            return;
        }
    }
    void AttackUpdate()
    {
        agent.SetDestination(targetTransform.position);

        if(canAttack)
        {
            anim.SetTrigger("attack");
            agent.Stop();
            //targetTransform.GetComponent<PlayerBehaviourScript>().Damage(damage);
            idleTime = coolDownAttack;
            SetIdle();
        }

        if(distanceFromTarget > attackRange)
        {
            SetChase();
            return;
        }

    }
    void StunUpdate()
    {
        if (timeCounter >= stunTime)
        {
            idleTime = 0;
            SetIdle();
        }
        else timeCounter += Time.deltaTime;
    }
    void DeadUpdate()
    {

    }
    #endregion
    #region Sets
    void SetIdle()
    {
        timeCounter = 0;
        //Animacion
        
        state = EnemyState.Idle;
    }
    void SetPatrol()
    {
        agent.Resume();
        
        agent.SetDestination(points[pathIndex].position);
        //Animacion

        state = EnemyState.Patrol;
    }
    void SetChase()
    {

        state = EnemyState.Chase;
    }
    void SetAttack()
    {
        state = EnemyState.Attack;
    }
    void SetStun()
    {
        agent.Stop();
        timeCounter = 0;
        state = EnemyState.Stun;
    }
    void SetDead()
    {
        //deadSound.Play();
        anim.SetTrigger("back_fall");

        agent.Stop();
        state = EnemyState.Dead;

        Destroy(this.gameObject, 1);
    }
    #endregion

    #region Public Functions
    public void Damage(int hit)
    {
        life -= hit;
        if(life <= 0)
        {
            SetDead();
        }
        else
        {
            SetStun();
        }
    }
    #endregion


    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Color newColor = Color.red;
        newColor.a = 0.2f;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void CalculateDistanceFromTarget()
    {
        distanceFromTarget = Vector3.Distance(transform.position, targetTransform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canAttack = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canAttack = false;
        }
    }


}
 