using System.Collections.Generic;

public class Video
{
    private string _titulo;
    private string _autor;
    private int _duracao; // em segundos
    private List<Comentario> _comentarios;

    public Video(string titulo, string autor, int duracao)
    {
        _titulo = titulo;
        _autor = autor;
        _duracao = duracao;
        _comentarios = new List<Comentario>();
    }

    public void AdicionarComentario(Comentario comentario)
    {
        _comentarios.Add(comentario);
    }

    public int GetNumeroDeComentarios()
    {
        return _comentarios.Count;
    }

    public string GetTitulo()
    {
        return _titulo;
    }

    public string GetAutor()
    {
        return _autor;
    }

    public int GetDuracao()
    {
        return _duracao;
    }

    public List<Comentario> GetComentarios()
    {
        return _comentarios;
    }
}
