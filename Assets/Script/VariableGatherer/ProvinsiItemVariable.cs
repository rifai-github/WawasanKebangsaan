using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class ProvinsiItemVariable : BaseVariableGatherer
{
    private Provinsi _Provinsi;

    public Provinsi GetProvinsi { get { return _Provinsi; } set { _Provinsi = value; } }
}
