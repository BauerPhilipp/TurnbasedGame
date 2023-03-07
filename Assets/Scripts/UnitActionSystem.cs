using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public event EventHandler OnSelectedUnitChanged;

    [SerializeField] Unit selectedUnit;
    [SerializeField] LayerMask unitLayermask;

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetMouseButtonDown(0))
        {
            if(TryHandleUnitSelection()) return;
            selectedUnit.Move(MouseWorld.GetPosition());
        }
    }

    bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayermask))
        {
            if(raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SetSelectedUnit(unit);
                return true;
            }
        };
        return false;
    }

    void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
