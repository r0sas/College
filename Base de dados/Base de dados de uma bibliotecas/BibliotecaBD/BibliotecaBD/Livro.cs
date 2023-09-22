using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Livro
{
	private string _autor;
	private string _titulo;
	private string _editora;
	private string _piso;
	private string _nome;
	private string _codigo;
	private int _quantidade;


	public String LivroAutor
	{
		get { return _autor; }
		set { _autor = value; }
	}

	public String LivroTitulo
	{
		get { return _titulo; }
		set { _titulo = value; }
	}

	public String LivroEditora
	{
		get { return _editora; }
		set { _editora = value; }
	}

	public String LivroPiso
	{
		get { return _piso; }
		set { _piso = value; }
	}

	public String LivroNome
	{
		get { return _nome; }
		set { _nome = value; }
	}

	public String LivroCodigo
	{
		get { return _codigo; }
		set { _codigo = value; }
	}

	public int LivroQuantidade
	{
		get { return _quantidade; }
		set { _quantidade = value; }
	}

	public override String ToString()
	{
		return _titulo;
	}
}
