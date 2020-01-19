using System.Collections;
using System.Collections.Generic;
using MakeAShape;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShapeSelectionPanel : MonoBehaviour
{
    [SerializeField] private Button _sphereButton;
    [SerializeField] private Button _cubeButton;
    [SerializeField] private Button _cylinderButton;
    [SerializeField] private StringAction _onShapeSelected;

    private ShapePanelAnimator _shapePanel;

    [Inject]
    public void Construct(ShapePanelAnimator shapePanel)
    {
        _shapePanel = shapePanel;
    }
    
    void Start()
    {
        _sphereButton.onClick.AddListener(() => ShowShapes("Sphere"));
        _cubeButton.onClick.AddListener(() => ShowShapes("Cube"));
        _cylinderButton.onClick.AddListener(() => ShowShapes("Cylinder"));
    }

    void ShowShapes(string shape)
    {
        _onShapeSelected.Invoke(shape);
        _shapePanel.HidePanel();
    }
}
