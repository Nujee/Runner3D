using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    public GameObject _activator;
    public List<ObjectView> _obstacles;
    public List<ObjectView> _pickups;
    public Transform _startPosition;
    public ObjectView _finish;

    public void IsActive(bool isActive)
    {
        _activator.SetActive(isActive);
    }
}
