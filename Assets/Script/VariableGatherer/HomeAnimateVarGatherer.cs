using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeAnimateVarGatherer : BaseVariableGatherer 
{
    [SerializeField]
    private List<Animator> _Animator;

    public List<Animator> GetAnimator { get { return _Animator; } }
}
