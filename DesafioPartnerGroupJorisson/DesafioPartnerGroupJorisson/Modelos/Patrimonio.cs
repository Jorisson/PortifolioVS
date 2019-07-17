namespace DesafioPartnerGroupJorisson.Modelos
{
    /// <summary>
    /// Classe Principal do Patrimonio
    /// </summary>
    public class Patrimonio
    {
        /// <summary>
        /// Id do Patrimonio, Criado para controle
        /// </summary>
        public long IdPatrimonio { get; set; }

        /// <summary>
        /// ID da Marca
        /// </summary>
        public long MarcaId { get; set; }

        /// <summary>
        /// Nome do Patrimonio
        /// </summary>
        public string NomePatrimonio { get; set; }

        /// <summary>
        /// Descrição do Patrimonio
        /// </summary>
        public string DescricaoPatrimonio { get; set; }

        /// <summary>
        /// Numero do Tombo
        /// </summary>
        public long NrTombo { get; set; }
    }
}
