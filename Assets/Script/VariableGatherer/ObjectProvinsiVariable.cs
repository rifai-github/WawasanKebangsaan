using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class ObjectProvinsiVariable : BaseVariableGatherer 
{
    [SerializeField]
    private Provinsi _Provinsi;

    public Provinsi PROVINSI { get { return _Provinsi; } }
}
