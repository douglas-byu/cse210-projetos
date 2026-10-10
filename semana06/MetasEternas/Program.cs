using System;

// =========================================================================================
// PROJETO METAS ETERNAS (ETERNAL QUEST) - CSE 210 SEMANA 06
// 
// Superando os requisitos (Exceeding Requirements):
// 1. Validação e integridade de metas: O sistema verifica se um objetivo já foi finalizado
//    antes de registrar novo progresso, evitando duplicação indevida de pontuação.
// 2. Tratamento robusto de entradas: Uso de int.TryParse para evitar erros de conversão no menu
//    e na seleção de itens.
// 3. Arquitetura OOP com Polimorfismo: Classe base abstrata 'Objetivo' com métodos polimórficos
//    (RegistrarProgresso, FoiCumprido, FormatarExibicao, SalvarEmLinha) e subclasses 
//    especializadas (ObjetivoSimples, ObjetivoRecorrente, ObjetivoContador).
// 4. Persistência de dados: Salvamento e carregamento resilientes usando delimitador '|'.
// =========================================================================================

class Program
{
    static void Main(string[] args)
    {
        GerenciadorDeObjetivos gerenciador = new GerenciadorDeObjetivos();
        gerenciador.Executar();
    }
}
