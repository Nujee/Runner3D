using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    public List<ObjectView> _obstacleViews;
    public List<ObjectView> _pickUpViews;
    public Transform _startPosition;
    public ObjectView _finishView;
    public GameObject _activator;
}
