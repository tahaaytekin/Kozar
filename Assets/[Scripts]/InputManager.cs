using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InputManager : MonoBehaviour
{
    private GameObject selectedObject;
    private Item currentItem;

    #region UpdateFunct
    private void Update()
    {
        DragAndDrop();
    }
    #endregion

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
    public void DragAndDrop()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("item"))
                    {
                        if (hit.collider.CompareTag("Door"))
                        {
                            print("Door On Click");
                            GameManager.instance.FinalState();
                        }
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                    currentItem = selectedObject.GetComponent<Item>();
                }

            }

        }


        if (selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, selectedObject.transform.position.y, worldPosition.z);
        }
        if (Input.GetMouseButtonUp(0) && selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

            #region Process Of Checking Item After Removing Mouse

            if (Mathf.Abs(selectedObject.transform.localPosition.z - currentItem.finalPos.z) < 2f)
            {
                print("Success");
                selectedObject.transform.position = currentItem.finalPos;
                selectedObject.tag = "Untagged";
                currentItem.sideItem.BaseState();

                GameManager.instance.items.Add(currentItem);
                GameManager.instance.items.Remove(currentItem.sideItem);

                GameManager.instance.SuccessSound();
            }
            else
            {
                print("Not Success");
                selectedObject.transform.position = new Vector3(worldPosition.x, selectedObject.transform.position.y, worldPosition.z);

            }
            #endregion

            selectedObject = null;
        }
    }
}
