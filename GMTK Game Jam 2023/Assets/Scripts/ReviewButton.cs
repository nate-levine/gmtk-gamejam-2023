using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewButton : MonoBehaviour
{
    public static ReviewButton Instance { get; private set; }

    public GameObject starEmitter;

    public AudioSource click;

    bool down;
    float downCounter;
    bool stop;
    float stopCounter;

    Renderer renderer0;
    Renderer renderer1;
    Color color0;
    Color color1;

    float r0;
    float g0;
    float b0;

    float r1;
    float g1;
    float b1;

    Vector3 startPos;

    bool slideIn;
    Vector3 slidePos;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        slidePos = transform.position;

        starEmitter = transform.GetChild(3).gameObject;
        var emmision = starEmitter.GetComponent<ParticleSystem>().emission;
        emmision.enabled = false;

        click = GetComponent<AudioSource>();

        down = false;
        downCounter = 0.0f;
        stop = false;
        stopCounter = 0.0f;

        renderer0 = transform.GetChild(0).GetComponent<Renderer>();
        renderer1 = transform.GetChild(1).GetComponent<Renderer>();
        color0 = renderer0.material.color;
        color1 = renderer1.material.color;

        r0 = color0.r;
        g0 = color0.g;
        b0 = color0.b;

        r1 = color1.r;
        g1 = color1.g;
        b1 = color1.b;

        slideIn = false;
        startPos = transform.position;
    }

    public void SlideIn()
    {
        slideIn = true;
    }

    public void PressAnimation()
    {
        click.Play();

        starEmitter.GetComponent<ParticleSystem>().Clear();
        starEmitter.GetComponent<ParticleSystem>().Play();
        var emmision = starEmitter.GetComponent<ParticleSystem>().emission;
        emmision.enabled = true;

        var main = starEmitter.GetComponent<ParticleSystem>().main;
        main.maxParticles = Random.Range(1, 6);

        Debug.Log(main.maxParticles);

        down = true;
    }
    public void StopAnimation()
    {
        stop = true;
    }

    private void Update()
    {
        if (slideIn)
        {
            if (transform.position.y - slidePos.y < 158.0f)
            {
                transform.position += new Vector3(0.0f, 150.0f, 0.0f) * Time.deltaTime;
            }
            if (transform.position.y - slidePos.y >= 158.0f)
            {
                slideIn = false;
                startPos = transform.position;
            }
        }
        if (down)
        {
            downCounter += 8.0f * Time.deltaTime;

            if (downCounter > 0.0f & downCounter < 1.0f)
            {
                transform.position -= new Vector3(0.0f, 1.0f, 0.0f) * 40.0f * Time.deltaTime;
            }
            if (downCounter >= 1.0f && downCounter < 2.0f)
            {
                transform.position -= new Vector3(0.0f, -1.0f, 0.0f) * 40.0f * Time.deltaTime;
            }
            if (downCounter >= 2.0f)
            {
                down = false;
                downCounter = 0.0f;
            }
        }

        if (stop)
        {
            stopCounter += 2.0f * Time.deltaTime;

            transform.position = startPos + new Vector3(Mathf.Sin(stopCounter * 200.0f / (2 * Mathf.PI)) * 100.0f / (stopCounter * 100.0f), 0.0f, 0.0f);

            if (stopCounter > 0.0f & stopCounter < 1.0f)
            {
                renderer0.material.color = new Color(Mathf.SmoothStep(1.0f, r0, stopCounter), Mathf.SmoothStep(0.0f, g0, stopCounter), Mathf.SmoothStep(0.0f, b0, stopCounter));
                renderer1.material.color = new Color(Mathf.SmoothStep(0.5f, r1, stopCounter), Mathf.SmoothStep(0.0f, g1, stopCounter), Mathf.SmoothStep(0.0f, b1, stopCounter));
            }
            if (stopCounter >= 1.0f)
            {
                stop = false;
                stopCounter = 0.0f;
            }
        }
    }
}
