using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    [SerializeField] private ObjectiveSkip objectiveSkip;

    private int index;

    private void Awake()
    {
        objectiveSkip = GameObject.Find("ObjectiveSkip").GetComponent<ObjectiveSkip>();
    }

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectiveSkip.nextObjective)
        {
            objectiveSkip.nextObjective = false;
            gameObject.SetActive(false);
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

}

