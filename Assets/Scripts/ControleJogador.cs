using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControleJogador : MonoBehaviour {
public Rigidbody jogador;
public GameObject cenario;
public float velocidadeJogador;
public float velocidadeCenario;
void Start() {
}
// Update is called once per frame
void Update() {
    transform.Rotate(new Vector3(0,90,0) * Time.deltaTime);
float direcao = Input.GetAxis("Horizontal");
//x->lateral, y->altura, z->profundidade
Vector3 move = new Vector3(direcao*velocidadeJogador,0,0);
jogador.AddForce(move);
//move o chao
cenario.transform.Translate(0,0,velocidadeCenario * Time.deltaTime * -1);
}
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Moeda")){
            Destroy(col.gameObject);
        } 
        if (col.gameObject.CompareTag("Obstaculo")){
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        
    }
}