using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    [Header("Detection Fields")]
    //detection point
    public Transform detectionPoint;
    //detection radius
    private const float detectionRadius = 0.2f;
    //detection layer
    public LayerMask detectionLayer;
    //cached triggere object
    public GameObject detectedObject;
    [Header("Examine Fields")]
    public GameObject examineWindow;
    public Image examineImage;
    public Text examineText;
    public bool isExamining;

    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                Debug.Log("Interact");
                //detectedObject.GetComponent<GameObject>().Interact();
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }

    // public void ExamineItem(GameObject item)
    // {
    //     if(isExamining)
    //     {
    //         //hide the examin window
    //         examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
    //         //write description text underneath the image
    //         examineText.text = item.descriptionText;
    //         examineWindow.SetActive(true);
    //         isExamining = true;
    //     }
    // }
    
}
