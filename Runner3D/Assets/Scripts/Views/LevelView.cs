using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    public GameObject _activator;
    public List<ObjectView> _obstacleViews;
    public List<ObjectView> _pickUpViews;
    public Transform _startPosition;
    public ObjectView _finishView;

    public void IsActive(bool isActive)
    {
        _activator.SetActive(isActive);
    }
}
