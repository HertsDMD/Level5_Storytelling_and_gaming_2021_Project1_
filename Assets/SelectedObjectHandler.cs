using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObjectHandler : MonoBehaviour
{
    // This script prevents multiple objects from being selected
    // it removes all other objects from the ObjectsToSelect layer when one of the objects has been selected
    // and moves them back once none of the obejct have been selected

    List<GameObject> goList = new List<GameObject>();
    bool _isDragging;
    string _selectedItemName;

    private void Start()
    {
        MoveObject_v2 moveObject = FindObjectOfType<MoveObject_v2>();
        moveObject.ItemSelectedEvent += ItemSelectedEvent;

        FindGameObjectsInLayer(8); // getting all objects within this list
    }
    GameObject[] FindGameObjectsInLayer(int layer)

    {
        var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == layer)
            {
                goList.Add(goArray[i]);
            }
        }
        if (goList.Count == 0)
        {
            return null;
        }
        return goList.ToArray();
    }

    void ItemSelectedEvent(string selectedItemName, bool isDragging)
    {
        _selectedItemName = selectedItemName;
        _isDragging = isDragging;
        UpdateNonSelectedObjects();

        // Update is called once per frame
        void UpdateNonSelectedObjects()
        {
            if (_isDragging)
            {
                foreach (var item in goList)
                {
                    if (item.transform.name == _selectedItemName)
                    {
                        item.gameObject.GetComponent<OutOfBounds_v2>().CheckForOutOfBounds();
                    }
                    else
                    {
                        item.gameObject.layer = 0;
                    }
                }
            }
            else
            {
                foreach (var item in goList)
                {
                    item.gameObject.layer = 8;
                }
            }
        }

    }
}
