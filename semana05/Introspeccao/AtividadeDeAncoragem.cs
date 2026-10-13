using System;
using System.Collections.Generic;

public class AtividadeDeAncoragem : Atividade
{
    private readonly List<(string Etapa, string Instrucao)> _etapasSensoriais = new List<(string, string)>()
    {
        ("5 - VISÃO", "Olhe ao seu redor e observe atentamente 5 coisas que você consegue VER (cores, formas, objetos ao redor)."),
        ("4 - TATO", "Sinta 4 coisas físicas que você pode TOCAR (a textura da sua roupa, o apoio dos pés no chão, a mesa sob suas mãos)."),
        ("3 - AUDIÇÃO", "Feche os olhos por um instante e note 3 sons distintos que você consegue OUVIR ao fundo."),
        ("2 - OLFATO", "Respire fundo e tente perceber 2 aromas ou cheiros presentes no ar ao seu redor."),
        ("1 - GRATIDÃO/PALADAR", "Concentre-se em 1 coisa boa ou pensamento pelo qual você sente profunda gratidão neste exato momento.")
    };

    public AtividadeDeAncoragem() : base(
        "Atividade de Ancoragem Sensorial (5-4-3-2-1)",
        "Esta atividade ajudará você a desacelerar e ancorar sua atenção no momento presente, utilizando seus sentidos para aliviar o estresse e a ansiedade.")
    {
    }

    public override void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine("Esta técnica de ancoragem guiará seus sentidos passo a passo para o agora.");
        Console.WriteLine();

        // Distribui o tempo total entre as 5 etapas, garantindo no mínimo alguns segundos por etapa
        int tempoPorEtapa = Math.Max(4, _duracao / _etapasSensoriais.Count);

        for (int i = 0; i < _etapasSensoriais.Count; i++)
        {
            var etapa = _etapasSensoriais[i];

            Console.WriteLine($"--- Etapa {etapa.Etapa} ---");
            Console.WriteLine(etapa.Instrucao);
            Console.Write("Concentre-se nessa percepção: ");
            ExibirContagemRegressiva(tempoPorEtapa);
            Console.WriteLine();
            Console.WriteLine();
        }

        ExibirMensagemFinal();
    }
}
