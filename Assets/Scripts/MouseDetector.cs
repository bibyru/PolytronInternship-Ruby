using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetector : MonoBehaviour
{
    [SerializeField] Camera cam;

    GameObject GameManager;

    private void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClick();
        }
    }

    void MouseClick()
    {
        Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit mouseHit))
        {
            GameObject collisionObject = mouseHit.collider.gameObject;
            if (collisionObject.name.Contains("Dirt") || collisionObject.name.Contains("Desert"))
            {
                collisionObject.GetComponent<HouseSpawner>().SpawnHouse();
            }
        }
    }
}
