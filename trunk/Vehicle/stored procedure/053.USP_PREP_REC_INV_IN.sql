SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type='P' AND name='.USP_PREP_REC_INV_IN') 
     DROP PROCEDURE [USP_PREP_REC_INV_IN] 
GO

CREATE PROCEDURE [dbo].[USP_PREP_REC_INV_IN] 
(
	@IS_FRZ BIT,
	@IS_BC BIT
) --WITH ENCRYPTION
AS 
BEGIN
	SET NOCOUNT ON

	DECLARE @ERROR_MSG NVARCHAR(MAX)

	BEGIN TRY
		IF NOT EXISTS(SELECT TOP 1 1 FROM tempdb.sys.objects WHERE type = 'U' AND name LIKE '#TMP_REC_INV_IN_INPUT')
		BEGIN
			SET @ERROR_MSG = '没有定义临时表#TMP_REC_INV_IN_INPUT表。'
			RAISERROR(@ERROR_MSG, 16, 1) 

			--收货入库输入参数表
			CREATE TABLE #TMP_REC_INV_IN_INPUT (
				VOU_LN INT PRIMARY KEY,
				ORD_LN INT,
				DLV_LN INT,
				TRANS_TP CHAR(3),
				PT_NO VARCHAR(20),
				UOM VARCHAR(3),
				BASE_UOM VARCHAR(3),
				UOM_CONV_RT DECIMAL(18, 8),
				LOC_CD VARCHAR(20),
				QLTY_TP CHAR(1),
				IS_CNMT BIT,
				QTY DECIMAL(18, 8),
				RSN_CD CHAR(3),
				INV_BN_ID INT,
				VER INT
			)

			--条码入库输入参数表
			CREATE TABLE #TMP_REC_INV_IN_BC_INPUT (
				BAR_CD VARCHAR(20) PRIMARY KEY,
				VOU_LN INT,
				QTY DECIMAL(18, 8),
				UOM VARCHAR(3),
				BASE_UOM VARCHAR(3),
				UOM_CONV_RT DECIMAL(18, 8)
			)
		END

		--记录需要更新库存明细的ID和VERSION
		UPDATE #TMP_REC_INV_IN_INPUT SET INV_BN_ID = B.INV_BN_ID, VER = B.VER
		FROM #TMP_REC_INV_IN_INPUT AS A INNER JOIN INV_BN AS B ON B.PT_NO = A.PT_NO 
															 AND B.LOC_CD = A.LOC_CD
															 AND B.QLTY_TP = A.QLTY_TP
															 AND B.IS_FRZ = @IS_FRZ
															 AND B.IS_BC = @IS_BC
															 AND B.IS_TR = 0
															 AND B.IS_CNMT = A.IS_CNMT
	END TRY
	BEGIN CATCH
		SET @ERROR_MSG = N'程序执行时发生错误:' + ERROR_MESSAGE() + N'，行数：' + ERROR_LINE()
		RAISERROR(@ERROR_MSG, 16, 1) 
	END CATCH
END
GO