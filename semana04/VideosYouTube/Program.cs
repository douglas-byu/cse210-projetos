using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Vídeo 1
        Video video1 = new Video("Como fazer bolo de chocolate", "Ana Cozinha", 360);
        video1.AdicionarComentario(new Comentario("Carlos", "Incrível receita, tentei e ficou perfeito!"));
        video1.AdicionarComentario(new Comentario("Maria", "Qual marca de chocolate você usa?"));
        video1.AdicionarComentario(new Comentario("João", "Melhor canal de culinária do YouTube!"));
        video1.AdicionarComentario(new Comentario("Fernanda", "Fiz ontem e todo mundo amou, obrigada!"));
        videos.Add(video1);

        // Vídeo 2
        Video video2 = new Video("Treino HIIT para iniciantes", "Fit com Bruno", 720);
        video2.AdicionarComentario(new Comentario("Lucas", "Esse treino é demais, já emagreci 3kg!"));
        video2.AdicionarComentario(new Comentario("Patrícia", "Consegui terminar sem parar pela primeira vez!"));
        video2.AdicionarComentario(new Comentario("Rafael", "Pode fazer todos os dias ou precisa descansar?"));
        videos.Add(video2);

        // Vídeo 3
        Video video3 = new Video("Top 10 destinos para 2025", "Viajando com Lena", 540);
        video3.AdicionarComentario(new Comentario("Roberto", "Já fui ao número 3, é incrível mesmo!"));
        video3.AdicionarComentario(new Comentario("Sofia", "Coloca o orçamento estimado para cada destino!"));
        video3.AdicionarComentario(new Comentario("Diego", "Vídeo muito bem editado, parabéns!"));
        video3.AdicionarComentario(new Comentario("Camila", "Adicionei todos na minha lista de viagens!"));
        videos.Add(video3);

        // Vídeo 4
        Video video4 = new Video("Programação orientada a objetos em C#", "Dev Tutoriais", 1200);
        video4.AdicionarComentario(new Comentario("André", "Finalmente entendi o conceito de classes!"));
        video4.AdicionarComentario(new Comentario("Bianca", "Você explica muito melhor que o meu professor."));
        video4.AdicionarComentario(new Comentario("Thiago", "Poderia fazer um vídeo sobre herança?"));
        videos.Add(video4);

        // Exibir todos os vídeos
        foreach (Video video in videos)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Título:             {video.GetTitulo()}");
            Console.WriteLine($"Autor:              {video.GetAutor()}");
            Console.WriteLine($"Duração:            {video.GetDuracao()} segundos");
            Console.WriteLine($"Nº de comentários:  {video.GetNumeroDeComentarios()}");
            Console.WriteLine("Comentários:");

            foreach (Comentario comentario in video.GetComentarios())
            {
                Console.WriteLine($"  - {comentario.GetNome()}: {comentario.GetTexto()}");
            }

            Console.WriteLine();
        }
    }
}