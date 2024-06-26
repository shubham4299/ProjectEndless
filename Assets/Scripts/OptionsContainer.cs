using Dreamteck.Forever;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OptionsContainer :Builder
{
    [SerializeField] private float m_speedBoostAmount = 2f;
    private float speed;
    private OptionTab[] _boostPoints;
    [SerializeField] private Material BaseMat;
    [SerializeField] private Material RightOptionMat;
    [SerializeField] private Material WrongOptionMat;
    [SerializeField] private int CorrectOptionPoints = 5;
    [SerializeField] private int WrongOptionPoints = 2;

    protected override void Build()
    {
        base.Build();

        _boostPoints = GetComponentsInChildren<OptionTab>();

        int CorrectIndex = UnityEngine.Random.Range(0, _boostPoints.Count());
        for(int i = 0; i< _boostPoints.Count(); i++)
        {
            _boostPoints[i].container = this;
            if (CorrectIndex == i) _boostPoints[i].IsCorrect = true;
            _boostPoints[i].GetComponent<MeshRenderer>().sharedMaterial = BaseMat;
        }
        Debug.Log("Build DONE");
    }



    //private void Start()
    //{
    //    foreach (OptionTab point in _boostPoints)
    //    {
    //        point.container = this;
    //        point.GetComponent<MeshRenderer>().sharedMaterial = BaseMat;
    //    }
    //}

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
