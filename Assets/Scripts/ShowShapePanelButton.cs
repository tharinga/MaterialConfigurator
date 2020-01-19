using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class ShowShapePanelButton : MonoBehaviour
{
    private ShapePanelAnimator _shapePanel;

    [Inject]
    public void Construct(ShapePanelAnimator shapePanel)
    {
        _shapePanel = shapePanel;
    }
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(_shapePanel.ShowPanel);
    }
}
