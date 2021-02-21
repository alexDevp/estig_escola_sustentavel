using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public Transform Instruction;

    void OnTriggerEnter(Collider other)
    {
        Instruction.gameObject.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        Instruction.gameObject.SetActive(false);

    }
}
