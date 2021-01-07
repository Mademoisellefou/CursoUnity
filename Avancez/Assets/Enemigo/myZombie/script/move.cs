using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] float decisionDelay = 3f;
    [SerializeField] Transform[] waypoints;
    int currentWaypoint = 0;
    Animator _ani;
    [Header("Player a Perseguir")]
    [SerializeField] Transform objectToChase;
    
    
    enum EnemyStates
    {
        Patrolling,
        Chasing
    }
    [Header("Audio")]
    public AudioClip attackAudio;//ATTACK AUDIO
    public AudioClip runAudio;//walk audio
    private AudioSource source;
    [Header("Animspeed")]
    public float speeda;

    [SerializeField] EnemyStates currentState;

    void Start()
    {
        source = GetComponent<AudioSource>();
        currentState = EnemyStates.Patrolling;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _ani.speed = speeda;  
        if (Vector3.Distance(transform.position, objectToChase.position) > 10f)
        {
            currentState = EnemyStates.Patrolling;
            agent.speed = 1.2f;
            _ani.SetBool("Walk", true);
            
        }
        else
        {
            currentState = EnemyStates.Chasing;

        }
        if (currentState == EnemyStates.Chasing) {
            agent.SetDestination(objectToChase.position);
            _ani.SetBool("Walk", false);
            _ani.SetTrigger("Hit");
            agent.speed = 5f;
            if (Input.GetKey(KeyCode.S))
            {
                currentWaypoint++;
                if (currentWaypoint == waypoints.Length)
                {
                    currentWaypoint = 0;
                }
                agent.SetDestination(waypoints[currentWaypoint].position);
            }
            if (source.clip != attackAudio)
            {
                source.clip = attackAudio;
                source.Play();
            }
        }
        if (currentState == EnemyStates.Patrolling)
        {
            if (source.clip != runAudio)
            {
                source.clip = runAudio;
                source.Play();
            }

            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) <= 0.6f)
            {
                currentWaypoint++;
                if (currentWaypoint == waypoints.Length)
                {
                    currentWaypoint = 0;
                }
            }
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }
    private void Awake()
    {
        _ani = GetComponent<Animator>();
    }
    void SetDestination()
    {
        if (currentState == EnemyStates.Patrolling)
            agent.SetDestination(objectToChase.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 5f);
    }
}