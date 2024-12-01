//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;
//using System.Data.Entity.Infrastructure;
//using System.Data; 
//using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.SqlClient;

namespace NotaEletronica.Models
{
    public class DB_ERPContext : DbContext
    { 
        public DB_ERPContext() : base("DB_Context")
        {
            Database.SetInitializer<DB_ERPContext>(null);
            this.Configuration.LazyLoadingEnabled = true; 
        }

       
        public DbSet<Boleto> Boleto { get; set; }
        public DbSet<BoletoConfiguracoes> BoletoConfiguracoes { get; set; }
        public DbSet<BoletoDocumento> BoletoDocumento { get; set; }
        public DbSet<TEmail> TEmail { get; set; }
        public DbSet<NFe> NFe { get; set; }
        public DbSet<NFeEmitente> NFeEmitente { get; set; }
        public DbSet<NFeMunicipio> NFeMunicipio { get; set; }
        public DbSet<NFeParametro> NFeParametro { get; set; }
        public DbSet<NFeProduto> NFeProduto { get; set; }
        public DbSet<NFeVencimentos> NFeVencimentos { get; set; }
        public DbSet<NFeXML> NFeXML { get; set; }
        public DbSet<CEST> CEST { get; set; }
        public DbSet<CFOP> CFOP { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<NCM> NCM { get; set; }
 
        public DbSet<NFeEmail> NFeEmail { get; set; }
        public DbSet<NFeInutiliza> NFeInutiliza { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<NFeProduto>().Property(x => x.qCom).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.vUnCom).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.vProd).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.qTrib).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.vUnTrib).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.vOutro).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ICMS_redBC).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ICMS_vBC).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ICMS_pICMS).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ICMS_vICMS).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ICMS_pMVAST).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ICMS_pRedBCST).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ICMS_vBCST).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ICMS_pST).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ICMS_vST).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ICMS_vBCSTRet).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ICMS_vICMSSTRet).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ICMS_pCredSN).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ICMS_vCredICMSSN).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.IPI_pIpi).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.IPI_vIPI).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.PIS_pPis).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.PIS_vPis).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.COFINS_pCofins).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.COFINS_vCofins).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.vFrete).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.vSeg).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.vDesc).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.IPI_vBC).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.PIS_vBC).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.COFINS_vBC).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.pis_qBCProd).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.pis_vAliqProd).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.cofins_qBCProd).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.cofins_vAliqProd).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ipi_qSelo).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ipi_qUnid).HasPrecision(18, 5);
            modelBuilder.Entity<NFeProduto>().Property(x => x.ipi_vUnid).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vBC).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vICMS).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vBCST).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vST).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vProd).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vFrete).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vSeg).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vDesc).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vII).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vIPI).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vPIS).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vCOFINS).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vOutro).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vNF).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vTotTrib).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vICMSDeson).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vICMSUFDest_Opc).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vICMSUFRemet).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vFCPUFDest).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vFCP).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vFCPST).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vFCPSTRet).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.tot_vIPIDevol).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.vol_qVol).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.vol_pesoL).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.vol_pesoB).HasPrecision(18, 5);
            modelBuilder.Entity<NFe>().Property(x => x.pag_vPag).HasPrecision(18, 5);
        }  
    }
}
