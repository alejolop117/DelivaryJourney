using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int changePerSecond = 1, interval = 3;
    [SerializeField] float angularMagnitude = 90;
    [Range(0,49)]
    [SerializeField] float pesoPorCaja;
    [SerializeField] Eventos deslizar, acelerate,ganarCaja,perderCaja,ganarVel;
    [SerializeField] float deslice,duracionDeslizar;
    [SerializeField] TextMeshProUGUI speedViewer;
    [SerializeField] AudioManager audioManager; 
    int speedView, counter = 0;
    public float speed = 150;
    Rigidbody rb;
    Vector3 direction = new Vector3(0,0,1);
    bool right = false, left = false;
    Animator anim;
    public int roadCounter = 0; // Para contar las pistas que ha pasado.
    [SerializeField]int resetCounter = 100; // Cada X pistas se reinicia el roadCounter
    
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        speed = speed - (pesoPorCaja * 3);
        deslice = deslice - (deslice * 0.3f);
        angularMagnitude = angularMagnitude - (angularMagnitude * 0.45f);
        ganarCaja.GEvent += PerderVel;
        perderCaja.GEvent += GanarVel;
        ganarVel.GEvent += GanarVel;
    }
    void Start()
    {
        deslizar.GEvent += ResbalarLlantas;
    }
    IEnumerator Deslizar()
    {
        angularMagnitude = angularMagnitude + deslice;
        yield return new WaitForSeconds(duracionDeslizar);
        angularMagnitude = angularMagnitude - deslice;
    }
    void ResbalarLlantas()
    {
        StartCoroutine("Deslizar");
    }

    void FixedUpdate() {
        Right();
        Left();
        Animations();
        ChangeSpeed();
        PrintText();
    }
    void GanarVel()
    {
        speed += pesoPorCaja;
        deslice += deslice * 0.1f;
        angularMagnitude += angularMagnitude * 0.15f;
    }
    void PerderVel()
    {
        speed -= pesoPorCaja;
        deslice -= deslice * 0.1f;
        angularMagnitude -= angularMagnitude * 0.15f;
    }

    void PrintText() {
        speedView = (int)speed;
        speedViewer.text = " SPEED:\n" + speedView.ToString() + " Km/h";
    }

    public void IsRight() {
        right = true;
    }

    public void IsNotRight() {
        right = false;
    }

    public void IsLeft() {
        left = true;
    }

    public void IsNotLeft() {
        left = false;
        
    }

    void Right() {

        if (right == true) {
            direction = new Vector3(1, 0, 0);
            rb.MovePosition(transform.position + (direction * angularMagnitude * Time.deltaTime));
            
        }
    }
    void Left() {

        if (left == true) {
            direction = new Vector3(-1, 0, 0);
            rb.MovePosition(transform.position + (direction * angularMagnitude * Time.deltaTime));
        }
    }

    void Animations() {
        if (right) anim.SetBool("IsTurnR", true);
        else if (!right) anim.SetBool("IsTurnR", false);
        
        if(left) anim.SetBool("IsTurnL", true);
        else if (!left) anim.SetBool("IsTurnL", false);
    }
    private void OnDestroy()
    {
        deslizar.GEvent -= ResbalarLlantas;
        ganarCaja.GEvent -= PerderVel;
        perderCaja.GEvent -= GanarVel;
        ganarVel.GEvent -= GanarVel;
    }
    private void OnDisable()
    {
        deslizar.GEvent -= ResbalarLlantas;
        ganarCaja.GEvent -= PerderVel;
        perderCaja.GEvent -= GanarVel;
    }

    private void OnTriggerEnter(Collider other) {


        if (other.CompareTag("Locator")) {
            roadCounter++;
            if (roadCounter == resetCounter) roadCounter = 0;
        }

        else if (other.CompareTag("Cone")) {
            audioManager.ConeCrash();
        }

        else if (other.CompareTag("Barrier")) {
            audioManager.BarrierCrash();
        }

        else if (other.CompareTag("Fence")) {
            audioManager.FenceCrash();
        }


    }

    void ChangeSpeed() {
        if (roadCounter % interval == 0) {
            speed += changePerSecond * Time.deltaTime;
            if (counter < 1) {
                AcelerateSound();
                counter++;
            }
        }
        else counter = 0;
    }
    void AcelerateSound() {
        acelerate.FireEvent();
    }
}
