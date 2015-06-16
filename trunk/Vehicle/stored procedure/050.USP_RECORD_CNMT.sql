SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type='P' AND name='USP_REC_CNMT') 
     DROP PROCEDURE [USP_REC_CNMT] 
GO

CREATE PROCEDURE [dbo].[USP_REC_CNMT] 
(
	@REC_NO VARCHAR(20),
	@ORD_NO VARCHAR(20),
	@DLV_NO VARCHAR(20),
	@EFF_DT DATE,
	@REC_CNMT_INPUT REC_CNMT_INPUT READONLY
) --WITH ENCRYPTION
AS 
BEGIN
	SET NOCOUNT ON
	DECLARE @ERROR_MSG NVARCHAR(MAX)
	DECLARE @ERROR_LN INT
	DECLARE @DATETIME_NOW DATETIME
	DECLARE @TRANS_CNT int

	SET @DATETIME_NOW = GETDATE()
	SET @TRANS_CNT = @@TRANCOUNT

	BEGIN TRY
		BEGIN TRY
			IF @REC_NO IS NULL
			BEGIN
				RAISERROR(50001, 16, 1, 'USP_REC_CNMT', '@REC_NO') 
			END

			IF @ORD_NO IS NULL
			BEGIN
				RAISERROR(50001, 16, 1, 'USP_REC_CNMT', '@ORD_NO') 
			END

			IF NOT EXISTS(SELECT TOP 1 1 FROM @REC_CNMT_INPUT)
			BEGIN
				RAISERROR(50001, 16, 1, 'USP_REC_CNMT', '@REC_CNMT_INPUT') 
			END

			SELECT C.PUR_PL_ID, C.SUPPL_CD, C.PT_NO, C.UOM, C.BASE_UOM, C.UOM_CONV_RT, A.CNMT_QTY, A.VER
			FROM CNMT_BN AS A 
			RIGHT JOIN @REC_CNMT_INPUT AS B ON A.PUR_PL_ID = B.PUR_PL_ID
			INNER JOIN PUR_PL AS C ON B.PUR_PL_ID = C.PUR_PL_ID


		END TRY
		BEGIN CATCH
			SET @ERROR_MSG = ERROR_MESSAGE()
			SET @ERROR_LN = ERROR_LINE()
			RAISERROR(50004, 16, 1, @ERROR_MSG, @ERROR_LN) 
		END CATCH

		BEGIN TRY
			IF @TRANS_CNT = 0
			BEGIN
				BEGIN TRAN
			END



			IF @TRANS_CNT = 0 
			BEGIN  
				COMMIT
			END
		END TRY
		BEGIN CATCH
			IF @TRANS_CNT = 0
			BEGIN
				ROLLBACK
			END 

			SET @ERROR_MSG = ERROR_MESSAGE()
			SET @ERROR_LN = ERROR_LINE()
			RAISERROR(50004, 16, 1, @ERROR_MSG, @ERROR_LN) 
		END CATCH
	END TRY
	BEGIN CATCH
		SET @ERROR_MSG = ERROR_MESSAGE()
		SET @ERROR_LN = ERROR_LINE()
		RAISERROR(50003, 16, 1, 'USP_CONVERT_UOM', @ERROR_MSG, @ERROR_LN) 
	END CATCH
END
GO