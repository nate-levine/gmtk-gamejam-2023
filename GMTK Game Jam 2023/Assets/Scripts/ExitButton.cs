using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButton : MonoBehaviour
{
    // Update is called once per frame
    public bool hover;
    public float hoverBuffer;
    Vector3 startPos;

    Renderer renderer0;
    Renderer renderer1;

    float r0;
    float g0;
    float b0;
    float r1;
    float g1;
    float b1;

    private void Start()
    {
        hoverBuffer = 0.0f;
        hover = false;
        startPos = transform.position;

        renderer0 = transform.GetChild(0).GetComponent<Renderer>();
        renderer1 = transform.GetChild(1).GetComponent<Renderer>();

        r0 = renderer0.material.color.r;
        g0 = renderer0.material.color.g;
        b0 = renderer0.material.color.b;
        r1 = renderer1.material.color.r;
        g1 = renderer1.material.color.g;
        b1 = renderer1.material.color.b;
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == "exit_button")
            {
                hover = true;
            }
        }
        else
        {
            hover = false;
        }

        if (Input.GetMouseButtonDown(0) && hover)
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (hover && hoverBuffer < 1.0f)
        {
            hoverBuffer += 5.0f * Time.deltaTime;
        }
        if (!hover && hoverBuffer > 0.0f)
        {
            hoverBuffer -= 5.0f * Time.deltaTime;
        }

        transform.position = startPos - new Vector3(0.0f, 1.0f * hoverBuffer, 0.0f);

        renderer0.material.color = new Color(Mathf.SmoothStep(r0, 1.0f, hoverBuffer), Mathf.SmoothStep(g0, 0.0f, hoverBuffer), Mathf.SmoothStep(b0, 0.0f, hoverBuffer));
        renderer1.material.color = new Color(Mathf.SmoothStep(r1, 0.5f, hoverBuffer), Mathf.SmoothStep(g1, 0.0f, hoverBuffer), Mathf.SmoothStep(b1, 0.0f, hoverBuffer));
    }
}
