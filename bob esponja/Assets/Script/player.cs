using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public int velocidade = 10;
    public int forcaPulo = 7;

    private Rigidbody rb;
    private AudioSource source;
    public AudioClip clipPulo, clipMoeda;

    public bool noChao;
 // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out source);
    }

        void OnCollisionEnter (Collision col){
            if(col.gameObject.tag == "Chao")
            {
                noChao = true;
            }
        }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");//-1 esquerda, 0 nada, 1 direita
        float v = Input.GetAxis("Vertical");// -1 pra tras, 0 nada, 1 para frente
        rb.AddForce(new Vector3(h, 0, v) * velocidade);

        if(Input.GetKeyDown(KeyCode.Space) && (noChao == true)){
            source.PlayOneShot(clipPulo);
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }

        if(transform.position.y <= -10){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
