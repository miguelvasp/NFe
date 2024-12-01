
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace NotaEletronica.Models
{
    [Table("BOLETOCNAB", Schema = "DBO")]
    public class Boleto
    {
        [Key]
        [DisplayName("IdBoleto")]
        [Column("IDBOLETO")]
        public int IdBoleto { get; set; }
 
        [DisplayName("Vencimento")]
        [Column("VENCIMENTO")]
        public DateTime? Vencimento { get; set; }
 
        [DisplayName("Instrucao")]
        [Column("INSTRUCAO")]
        public int? Instrucao { get; set; }
 
        [DisplayName("nroDias")]
        [Column("NRODIAS")]
        public int? nroDias { get; set; }
 
        [DisplayName("cedente_cpf")]
        [Column("CEDENTE_CPF")]
        public string cedente_cpf { get; set; }
 
        [DisplayName("cedente_nome")]
        [Column("CEDENTE_NOME")]
        public string cedente_nome { get; set; }
 
        [DisplayName("cedente_agencia")]
        [Column("CEDENTE_AGENCIA")]
        public string cedente_agencia { get; set; }
 
        [DisplayName("cedente_digitoagencia")]
        [Column("CEDENTE_DIGITOAGENCIA")]
        public string cedente_digitoagencia { get; set; }
 
        [DisplayName("cedente_conta")]
        [Column("CEDENTE_CONTA")]
        public string cedente_conta { get; set; }
 
        [DisplayName("cedente_digitoconta")]
        [Column("CEDENTE_DIGITOCONTA")]
        public string cedente_digitoconta { get; set; }
 
        [DisplayName("cedente_codigo")]
        [Column("CEDENTE_CODIGO")]
        public string cedente_codigo { get; set; }
 
        [DisplayName("ValorBoleto")]
        [Column("VALORBOLETO")]
        public decimal? ValorBoleto { get; set; }
 
        [DisplayName("Carteira")]
        [Column("CARTEIRA")]
        public string Carteira { get; set; }
 
        [DisplayName("NossoNumero")]
        [Column("NOSSONUMERO")]
        public string NossoNumero { get; set; }
 
        [DisplayName("NumeroDocumento")]
        [Column("NUMERODOCUMENTO")]
        public string NumeroDocumento { get; set; }
 
        [DisplayName("sacado_cpf")]
        [Column("SACADO_CPF")]
        public string sacado_cpf { get; set; }
 
        [DisplayName("sacado_nome")]
        [Column("SACADO_NOME")]
        public string sacado_nome { get; set; }
 
        [DisplayName("sacado_endereco")]
        [Column("SACADO_ENDERECO")]
        public string sacado_endereco { get; set; }
 
        [DisplayName("sacado_bairro")]
        [Column("SACADO_BAIRRO")]
        public string sacado_bairro { get; set; }
 
        [DisplayName("sacado_cidade")]
        [Column("SACADO_CIDADE")]
        public string sacado_cidade { get; set; }
 
        [DisplayName("sacado_cep")]
        [Column("SACADO_CEP")]
        public string sacado_cep { get; set; }
 
        [DisplayName("sacado_uf")]
        [Column("SACADO_UF")]
        public string sacado_uf { get; set; }
 
        [DisplayName("InstrucaoDescricao")]
        [Column("INSTRUCAODESCRICAO")]
        public string InstrucaoDescricao { get; set; }
 
        [DisplayName("DiasAposVencimento")]
        [Column("DIASAPOSVENCIMENTO")]
        public int? DiasAposVencimento { get; set; }
 
        [DisplayName("InstrucaoDescricao2")]
        [Column("INSTRUCAODESCRICAO2")]
        public string InstrucaoDescricao2 { get; set; }
 
        [DisplayName("InstrucaoDescricao3")]
        [Column("INSTRUCAODESCRICAO3")]
        public string InstrucaoDescricao3 { get; set; }
 
        [DisplayName("IdDocumentoEletronico")]
        [Column("IDDOCUMENTOELETRONICO")]
        public int? IdDocumentoEletronico { get; set; }
 
        [DisplayName("TipoDocumento")]
        [Column("TIPODOCUMENTO")]
        public string TipoDocumento { get; set; }

        public int? Lote { get; set; }

        public string Situacao { get; set; }

        public int numeroBanco { get; set; }
        public string Convenio { get; set; }
        public DateTime? Emissao { get; set; }
        public DateTime? Processamento { get; set; }

        public string EnviouEmail { get; set; }
        public string Impressao { get; set; }


    }
}
