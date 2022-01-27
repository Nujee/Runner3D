using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    public Text _scoreText;
    public Button _restartButton;
    public Button _nextLevelButton;
    public GameObject _activator;

    public void IsActive(bool isActive)
    {
        _activator.SetActive(isActive);
    }
}
