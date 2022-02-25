using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    public List<Transform> ruta;

    private int puntoRuta = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();

        SeleccionarPuntoRuta();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x == ruta[puntoRuta].position.x && transform.position.z == ruta[puntoRuta].position.z){
            ActualizarRuta();
        }
        if(Vector3.Distance(transform.position, player.transform.position) < 5){
            agent.destination = player.transform.position;
        }else{
            SeleccionarPuntoRuta();
        }
    }

    private void SeleccionarPuntoRuta(){
        agent.destination = ruta[puntoRuta].position;
    }

    private void ActualizarRuta(){
        if (puntoRuta == (ruta.Count) - 1){
            puntoRuta = 0;
        }else {
            puntoRuta++;
        }

        SeleccionarPuntoRuta();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag.Equals("Player")){
            Debug.Log("Golpisa");
        }
    }

}
