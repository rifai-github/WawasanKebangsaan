using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamaSukuVariable : BaseVariableGatherer 
{
    [SerializeField]
    private Text _NamaSuku;

    public Text GetSukuText { get { return _NamaSuku; } }
}
