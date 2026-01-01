USE [NBF_ITUM]
GO

/****** Object:  View [dbo].[vwProduto]    Script Date: 1/1/2026 6:14:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 

ALTER VIEW [dbo].[vwProduto]
as

SELECT distinct IT.INF_ITEM, NF.NFI_CODI
	,IT.PRO_COD AS Prod_cProd
	,''	Prod_cEAN
	,isnull(IT.PRO_DESC, '') Prod_xProd
	,
	CASE WHEN NF.TDOC_ID = 17 THEN isnull(IT.ncm, '')
	ELSE
	isnull(p.ncm, '99999999') END AS Prod_NCM
	,'' Prod_ExTIPI
	,CASE WHEN SUBSTRING('', 1, 2) = '' THEN '00' ELSE '00' END Prod_genero
	,isnull(C.CFA_CODI, '') Prod_CFOP
	,isnull(SUBSTRING(U.UVEN_NOME, 1, 2), 'PC') Prod_uCOM
	,isnull(ROUND(IT.INF_QTDE, 2), 0.00) Prod_qCom
	,isnull(round(IT.INF_PUNI, 6), 0.00) Prod_vUnCom
	,ROUND(IT.INF_QTDE, 2) * round(IT.INF_PUNI, 6) Prod_vProd
	,'' Prod_cEANTrib
	,isnull(SUBSTRING(U.UVEN_NOME, 1, 2), 'PC') Prod_uTrib
	,ROUND(IT.INF_QTDE, 2) Prod_qTrib
	,round(IT.INF_PUNI, 6) Prod_vUnTrib
	,ISNULL(0.00, 0.00) Prod_vFrete
	,0 Prod_vSeguro
	,ISNULL(0.00, 0.00) prod_Vdesc
	,'' Prod_DI
	,'' Prod_DetEspecifico
	,'' Prod_infAdProd
	
	--GRUPO DE ICMS
	,isnull(P.PRO_ORIGEM, '0') icms_orig
	,C.CFA_TICM icms_CST --ADICIONADO MAIS UM CARACTER NO TICM DO FATURAMENTO
	,3 icms_modBC
	,0 icms_pRedBC
	,isnull(IT.INF_BICM, 0) icms_vBC
	,isnull(IT.INF_AICM, 0) icms_pICMS
	,isnull(IT.INF_VICM, 0) icms_vICMS
	,0 icms_modBCST
	,0 icms_pmVAST
	,0 icms_pRedBCST
	,isnull(IT.INF_BICM, 0) icms_BCST	
	,isnull(IT.INF_VICM, 0) icms_vICMSST	
	,0.00 icms_pICMSST
	
	--GRUPO DE IPI
	,'' ipi_clEnq
	,'' ipi_CNPJProd
	,'' ipi_cSelo
	,0 ipi_qSelo
	,'999' ipi_cEnq
	,'53' ipi_CST
	,CASE WHEN ISNULL(IT.INF_AIPI, 0) <> 0 THEN IT.INF_QTDE * IT.INF_PUNI ELSE 0 END ipi_vBC
	,isnull(IT.INF_AIPI, 0) ipi_pIPI
	,isnull(IT.INF_VIPI, 0) ipi_vIPI
	,0 ipi_qUnid
	,0 ipi_vUnid
		
	--GRUPO DE PIS
	,C.CST_PIS pis_CST
	,CASE WHEN isnull(C.ALQ_PIS, 0.00) = 0 THEN 0 ELSE IT.INF_QTDE * IT.INF_PUNI END pis_vBC
	,isnull(C.ALQ_PIS, 0.00) pis_pPIS
	,0 pis_vPIS
	,0 pis_qBCProd
	,0 pis_vAliqProd
	
	--GRUPO DE COFINS //VERSAO 4.1 DA NFE DA NBF
	
	,C.CST_COFINS cofins_CST
	,CASE WHEN isnull(C.ALQ_COFINS, 0.00) = 0 THEN 0 ELSE IT.INF_QTDE * IT.INF_PUNI END  cofins_vBC
	,C.ALQ_COFINS cofins_pCOFINS
	,0 cofins_vCOFINS
	,0 cofins_qBCProd
	,0 cofins_vAliqProd
	,INF_CODI  AS IdExternoItem,

	--IMPOSTOS REFORMA TRIBUTARIA
	CST.Codigo CBS_SituacaoTributariaId,
	CCT.Codigo CBS_ClassificacaoTributariaId
	
FROM NF NF 
INNER JOIN   NF_ITENS IT  ON IT.NFI_CODI = NF.NFI_CODI 
LEFT OUTER JOIN FATURAMENTO C ON NF.CFA_ID = C.CFA_ID 
LEFT OUTER JOIN UNIDVENDA U ON IT.UVEN_ID = U.UVEN_ID 
LEFT OUTER JOIN PRODUTO P ON IT.PRO_ID = P .PRO_ID
LEFT OUTER JOIN CodigoSituacaoTributaria CST ON C.CBS_SituacaoTributariaId = CST.Id
LEFT OUTER JOIN CodigoClassificacaoTributaria CCT ON C.CBS_ClassificacaoTributariaId = CCT.Id

























GO


