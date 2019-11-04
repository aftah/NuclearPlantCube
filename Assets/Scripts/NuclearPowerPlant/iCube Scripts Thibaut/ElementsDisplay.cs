using System.Collections;
using System.Collections.Generic;
using ThibautPetit;
using TMPro;
using UnityEngine;

public class ElementsDisplay : MonoBehaviour
{
    [SerializeField] private ReceiverIDCheck receiver;
    [SerializeField] private TextMeshPro tmp;

    private void Update()
    {
        tmp.text = receiver.RequiredID.ToString();
    }
}
