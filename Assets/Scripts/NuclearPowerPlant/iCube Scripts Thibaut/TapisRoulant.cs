using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapisRoulant : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool movingLeft = false;
    [SerializeField] private bool movingForward = false;
    [SerializeField] private bool movingRight = false;
    [SerializeField] private bool movingBack = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Element"))
            MoveElement(other.gameObject);

    }

    private void MoveElement(GameObject elem)
    {
        if (movingLeft)
            elem.transform.Translate(Vector3.left * speed * Time.deltaTime);

        else if (movingRight)
            elem.transform.Translate(Vector3.right * speed * Time.deltaTime);

        else if (movingBack)
            elem.transform.Translate(Vector3.back * speed * Time.deltaTime);

        else if (movingForward)
            elem.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
