using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class bossflip : MonoBehaviour
{
    public enum statesE { follow ,stop}
    Transform playerp;
    [SerializeField]
    float speed =1f;
    Rigidbody2D rb;
    statesE est1 =statesE.follow;
    bosshealth boshealth;
    public float separacion=1.8f;
    public float StopD;


    private void Awake()
    {
        playerp = GameObject.FindGameObjectWithTag("Player").transform;
        boshealth = GetComponent<bosshealth>(); 
        rb = GetComponent<Rigidbody2D>();
    }
    void Girar() {
        Vector3 dir = playerp.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void Mover()
    {
        //Vector2 target = new Vector2(playerp.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, playerp.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
    private void Update()
    {
        
        switch (est1)
        {
            case statesE.follow:
                //print(Vector3.Distance(transform.position, playerp.position));
                if (Vector3.Distance(transform.position, playerp.position) < StopD) {
                    est1=statesE.stop;
                }
                Girar();
                Mover();
                break;

            case statesE.stop:

                if (Vector3.Distance(transform.position, playerp.position) >separacion)
                {
                    est1 = statesE.follow;
                }
                Girar();
                break;

            default:
                break;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boshealth.atacado();
            collision.gameObject.GetComponent<heallplayer>().damage();

        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boshealth.atacado();
            collision.gameObject.GetComponent<heallplayer>().damage();

        }
    }


}
