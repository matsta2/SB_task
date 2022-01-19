using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class ObjectClick : MonoBehaviour
{

    private GameObject objectToCreate;

    [SerializeField] private List<GameObject> furnitureList;
    [SerializeField] private Material cubeMaterial;
    [SerializeField] private Slider _slider;
    public float xLimit = 90f;

    public List<GameObject> currentObjects;

    private void Start()
    {
        objectToCreate = furnitureList[0];
        _slider.onValueChanged.AddListener(delegate
        {
            RotateMe();
        });
    }
    
    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var obj =Instantiate(objectToCreate, new Vector3(hit.point.x, hit.point.y + (objectToCreate.transform.localScale.y/2), hit.point.z), default);
            currentObjects.Add(obj);
        }
    }

    public void Btn1()
    {
        objectToCreate = furnitureList[0];
    }
    
    public void Btn2()
    {
        objectToCreate = furnitureList[1];
    }
    
    public void Btn8()
    {
        objectToCreate = furnitureList[2];
    }
    
    public void Btn3()
    {
        DeleteObjects();
    }

    public void Btn4()
    {
        cubeMaterial.color = Color.red;
    }
    public void Btn5()
    {
        cubeMaterial.color = Color.blue;
    }
    public void Btn6()
    {
        cubeMaterial.color = Color.yellow;
    }
    public void Btn7()
    {
        cubeMaterial.color = Color.green;
    }

    private void DeleteObjects()
    {
        foreach (var obj in currentObjects.ToArray())
        {
            Destroy(obj);
            currentObjects.Remove(obj);
        }
    }
    public void RotateMe()
    {
        for(var i = 0; i < currentObjects.Count; i++)
        {
            var item = currentObjects[i];
            item.transform.localEulerAngles = new Vector3(0, _slider.value * xLimit, 0);
        }
    }
}
