using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputField : MonoBehaviour
{
    public TMP_InputField inputField;

    public TMP_InputField siblingInput;
    public TMP_InputField nextSibling;
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    private void Update()
    {
        if (inputField.isFocused == true)
        {
            inputField.gameObject.GetComponent<RectTransform>().localScale = new Vector3(9.0f / 8.0f, 9.0f / 8.0f, 1.0f);

            /*if (Input.GetKeyDown(KeyCode.Return))
            {
                Transform parent = transform.parent;
                int index = transform.GetSiblingIndex();

                List<int> nextSiblingIndices = new List<int>();
                for (int i = index + 1; i < parent.childCount; i++)
                {
                    siblingInput = parent.GetChild(i).GetComponent<TMP_InputField>();

                    if (parent.GetChild(i).GetComponent<TMP_InputField>())
                    {
                        nextSiblingIndices.Add(i);
                    }
                }
                Debug.Log(nextSiblingIndices[0]);

                parent.GetChild(nextSiblingIndices[0]).GetComponent<TMP_InputField>().ActivateInputField();
            }*/
        }
        else if (inputField.isFocused == false)
        {
            inputField.gameObject.GetComponent<RectTransform>().localScale = new Vector3(8.0f / 9.0f, 8.0f / 9.0f, 1.0f);

        }
    }
}
