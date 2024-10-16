using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAIF : MonoBehaviour
{
    public NavMeshAgent ai;
    public List<Transform> destinations;
    public Animator aiAnim;
    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, idleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime, jumpscareTime;
    public bool walking, chasing, dead;
    public GameObject player, deathScreen, dialPuzzleCamera;
    Transform currentDest;
    Vector3 dest;
    int randNum;
    public int destinationAmount;
    public Vector3 rayCastOffset;
    public string deathScene;

    void Start()
    {
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];

    }
    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
        {
            Debug.DrawRay(transform.position + rayCastOffset, transform.forward * sightDistance, Color.green);
            if (hit.collider.gameObject.tag == "Player")
            {


                walking = false;
                StopCoroutine("stayIdle");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");
                chasing = true;
            }

        }

        else
        {
            Debug.DrawRay(transform.position + rayCastOffset, transform.forward * sightDistance, Color.red);
        }
        if (chasing == true)
        {
            if (player.activeSelf)
            {
                dest = player.transform.position;
                ai.destination = dest;
                ai.speed = chaseSpeed;
                //aiAnim.ResetTrigger("walk");
                //aiAnim.ResetTrigger("idle");
                //aiAnim.SetTrigger("sprint");
                float distance = Vector3.Distance(player.transform.position, ai.transform.position);
                Debug.Log(distance);
                if (distance <= catchDistance)
                {
                    dead = true;
                    player.gameObject.SetActive(false);
                    //aiAnim.ResetTrigger("walk");
                    //aiAnim.ResetTrigger("idle");
                    //aiAnim.ResetTrigger("sprint");
                    //aiAnim.SetTrigger("jumpscare");
                    chasing = false;
                }
            }

        }
        if (!player.activeSelf)
        {
            chasing = false;
        }

        if (dead)
        {
            StartCoroutine(DeathRoutine());
        }


        if (walking == true)
        {
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            //aiAnim.ResetTrigger("sprint");
            //aiAnim.ResetTrigger("idle");
            //aiAnim.SetTrigger("walk");
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                //aiAnim.ResetTrigger("sprint");
                //aiAnim.ResetTrigger("walk");
                //aiAnim.SetTrigger("idle");
                ai.speed = 0;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                walking = false;
            }

        }
    }
    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }
    IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }
    IEnumerator DeathRoutine()
    {
        deathScreen.SetActive(true);
        if (dialPuzzleCamera != null)
        {
            dialPuzzleCamera.SetActive(false);
        }

        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(deathScene);
    }
}

