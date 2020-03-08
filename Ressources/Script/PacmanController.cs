using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class PacmanController : MonoBehaviour {

    public int Speed = 5;
    public AudioClip SoundCoinIn;
    public AudioClip SoundDead;
    public AudioClip GhostDead;
    public AudioClip SoundGameOver;
    private Animator anim;
    public AudioClip SoundWin;
    public int BalleRestante;

    void Start()
    {
        anim = GetComponent<Animator>();

        //donner a vos object un tag Ball ou PacGum pour les récup, PS man google "Tag unity"
        GameObject[] Ball = GameObject.FindGameObjectsWithTag("Ball");
        GameObject[] Pacball = GameObject.FindGameObjectsWithTag("PacGum");
        BalleRestante = Ball.Length + Pacball.Length;
    }

    void Update () {

        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.eulerAngles = Vector3.up * 0;
            transform.Translate(transform.TransformDirection(Vector3.forward) * Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime);
            
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            //Angles
            //Move
        }
        //Conditions

        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
    }

    void PlayCoin()
    {
        if (!GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().PlayOneShot(SoundCoinIn);
    }

    void VerifBalle()
    {
        if (BalleRestante == 0) {
            //Win effect
            GetComponent<AudioSource>().PlayOneShot(SoundWin);
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag=="Ball") {
            BalleRestante -= 1;
            VerifBalle();
            //Actualise le score
            PlayCoin();
            Destroy(Col.gameObject);
        }
        if (Col.gameObject.tag == "PacGum")
        {
            //Pick up effect, comme la ball normal quoi
            //

            //Trouver les Ghosts
            GameObject[] Go;
            Go = GameObject.FindGameObjectsWithTag("Ghost");

            foreach (GameObject G in Go)
            {
                //Faire des effects graphiques sur les Ghosts
                //

                //Puis les passer en mode "run for your life !!"
                G.GetComponent<AI>().ModeAttack = false;
            }
            StartCoroutine(ModeAttackDelai());
        }
    }

    IEnumerator ModeAttackDelai()
    {
        //Direct
        //La suite de la fonction va se jouer 10s après l'appel de la fonction
        yield return new WaitForSeconds(10);
        //Après 10s
        


        //Trouver les Ghost, regarde en haut comment faire

        foreach (GameObject G in Go)
        {
            //Remettre les effects a leurs état d'origine
            //G.GetComponent<AI>().ModeAttack =;
        }
    }
    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "Ghost")
        {
            if( GameObject.FindGameObjectWithTag("Ghost").GetComponent<AI>().ModeAttack)
            {
                //Pacman passe un sale moment... Donc...
                //GetComponent<AudioSource>().;

                //Regarde si ta le temp les animations
                //anim.SetTrigger("Dead");
                
                //Le controller se désactive
                GetComponent<PacmanController>().enabled = false;

                //Stop Agents
                //Donc trouve les Ghost puis dis leur *************************************************
                foreach (GameObject G in Go)
                {
                    G.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                    //G.GetComponent<AI>().enabled = ;
                }

                //Perd une Vie
                
            }
            else
            {
                //Les fantomes se font avaler
                //L'amusement est TOTALE !

                //GetComponent<AudioSource>().;
                //Col.gameObject.GetComponent<AI>().Depart = ;

                //Repart au Depart... LOL des blagues...
                Instantiate(Col.gameObject, GameObject.Find("SpawnEnemy").transform.position, Quaternion.identity);
                Destroy(Col.gameObject);
            }
        }
    }

   

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2);
        /*
        if(//la vie)
        {
            //anim.SetTrigger("Spawn");
            transform.position = GameObject.Find("SpawnPacman").transform.position;
            GetComponent<PacmanController>().enabled = true;

            foreach (GameObject G in Go)
            {
                G.transform.position = GameObject.Find("Depart").transform.position;
                G.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                G.GetComponent<AI>().enabled = true;
                //custom
            }
        }
        else
        {
            //Game Over
            GetComponent<AudioSource>().PlayOneShot(SoundGameOver);
        }*/
    }
}
