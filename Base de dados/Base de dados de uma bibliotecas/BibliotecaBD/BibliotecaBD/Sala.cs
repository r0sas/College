using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Sala
{
    private string _edificio;
    private string _piso;
    private string _id_no_piso;
    private string _chave;
        

    public String SalaEdificio
    {
        get { return _edificio; }
        set { _edificio = value; }
    }

    public String SalaPiso
    {
        get { return _piso; }
        set { _piso = value; }
    }

    public String SalaId
    {
        get { return _id_no_piso; }
        set { _id_no_piso = value; }
    }

    public String SalaChave
    {
        get { return _chave; }
        set { _chave = value; }
    }

    public override String ToString()
    {
        return _edificio + "." + _piso + "  " + _id_no_piso;
    }
}
