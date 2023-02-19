using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    protected NavMeshAgent enemyMesh;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMesh.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide! restart!!!");
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        audioSource.Play();

        yield return new WaitForSeconds(0.5f);
        GameManagement.instance.restartGame();

    }
}
