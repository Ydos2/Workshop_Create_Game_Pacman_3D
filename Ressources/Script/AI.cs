using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    public bool ModeAttack = true;
    public Transform Target;
    public AudioClip SoundMAF;
    private UnityEngine.AI.NavMeshAgent agent;
    public float Depart;

	// Use this for initialization
	void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > Depart)
        {
            if(ModeAttack)
            {
                agent.SetDestination(Target.position);
            }
            else
            {
                //Sound
                agent.SetDestination(-Target.position);
            }
        }
	}
}
