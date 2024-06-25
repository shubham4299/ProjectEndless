using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsContainer : MonoBehaviour
{
    [SerializeField] private float m_speedBoostAmount = 2f;
    private float speed;
    private OptionTab[] _boostPoints;
    [SerializeField] private Material BaseMat;
    [SerializeField] private Material RightOptionMat;
    [SerializeField] private Material WrongOptionMat;
    [SerializeField] private int CorrectOptionPoints = 5;
    [SerializeField] private int WrongOptionPoints = 2;

    private void Awake()
    {
        _boostPoints = GetComponentsInChildren<OptionTab>();
    }

    private void Start()
    {
        foreach (OptionTab point in _boostPoints)
        {
            point.container = this;
            point.GetComponent<MeshRenderer>().sharedMaterial = BaseMat;
        }
    }

    public void OnRightOptionHit()
    {
        foreach (OptionTab point  in _boostPoints)
        {
            if (point.IsCorrect)
                point.SetMaterial(RightOptionMat);
        }
        PlayerController.instance.SetSpeed(PlayerController.instance.GetSpeed() + m_speedBoostAmount);
        ScoreManager.instance.AddScore(CorrectOptionPoints);
    }

    public void OnWrongOptionHit()
    {
        foreach (OptionTab point in _boostPoints)
        {
            if (point.IsCorrect)
                point.SetMaterial(RightOptionMat);
            else
                point.SetMaterial(WrongOptionMat);
        }
        PlayerController.instance.SetSpeed(PlayerController.instance.GetSpeed() - m_speedBoostAmount);
        ScoreManager.instance.ReduceScore(WrongOptionPoints);
    }
}
