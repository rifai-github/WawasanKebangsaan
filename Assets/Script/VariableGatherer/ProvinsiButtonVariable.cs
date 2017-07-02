using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WawasanKebangsaanBase;

public class ProvinsiButtonVariable : BaseVariableGatherer 
{
    [SerializeField]
    private Text _Text;

    public Text GetText { get { return _Text; } }
}
