USE [Sconit]
GO
/****** Object:  StoredProcedure [dbo].[USP_Busi_MRP_MiShipDailyPlanTrack]    Script Date: 12/08/2014 15:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[USP_Busi_MRP_MiShipDailyPlanTrack] '2013-11-26 09:33:58.000','2013-11-27 15:09:16.000'


ALTER PROCEDURE [dbo].[USP_Busi_MRP_MiShipDailyPlanTrack]
 (
 @FormerVersion datetime ,
 @LatterVersion datetime 
 )
AS
BEGIN
	SET NOCOUNT ON
	Declare @CurrentDate datetime
	--select @FormerVersion='2013-11-26 09:33:58.000',@LatterVersion='2013-11-27 15:09:16.000'
	--Select * from mrp_mrpplanmaster with(nolock) where ResourceGroup = 10  and PlanVersion  in ('2013-11-26 09:33:58.000','2013-11-27 15:09:16.000')
	select * into #MRP_MrpShipPlan1 from MRP_MrpShipPlan where PlanVersion  in (@LatterVersion,@FormerVersion) and Flow like '%MI%'
	select * into #MRP_MrpShipPlan2 from MRP_MrpShipPlan where PlanVersion  in (@LatterVersion,@FormerVersion) and Flow like '%MI%'
	Update #MRP_MrpShipPlan1 Set Qty = 0 where PlanVersion=@LatterVersion
	Update #MRP_MrpShipPlan2 Set Qty = 0 where PlanVersion=@FormerVersion
	--select *  from MRP_MrpShipPlan where PlanVersion  in ('2013-11-26 09:33:58.000' ) and Flow like '%MI%' union
	--select distinct Item  from MRP_MrpShipPlan where PlanVersion  in ( '2013-11-27 15:09:16.000') and Flow like '%MI%'

	Create index IX_Item on  #MRP_MrpShipPlan1 (item)
	Create index IX_Item on  #MRP_MrpShipPlan2 (item)
	Select s.Item ,b.Desc1 ,b.UC ,dbo.FormatDate(s.StartTime,'YYYY/MM/DD') as PlanDate,round(SUM(s.Qty)/b.UC,1) as Qty into #MrpShipPlan1 
		 from #MRP_MrpShipPlan1 s , MD_Item b with(nolock)
		 where s.item=b.Code group by  s.Item,b.Desc1 ,b.UC ,dbo.FormatDate(s.StartTime,'YYYY/MM/DD')
	Select s.Item ,b.Desc1 ,b.UC ,dbo.FormatDate(s.StartTime,'YYYY/MM/DD') as PlanDate,round(SUM(s.Qty)/b.UC,1) as Qty into #MrpShipPlan2 
		 from #MRP_MrpShipPlan2 s , MD_Item b with(nolock)
		 where s.item=b.Code group by  s.Item,b.Desc1 ,b.UC ,dbo.FormatDate(s.StartTime,'YYYY/MM/DD')
	--select distinct dbo.FormatDate( StartTime,'YYYY/MM/DD') from  #MRP_MrpShipPlan
	--Show the data of the first version
	Declare @SQL varchar(max)=''
	Declare @SQL1 varchar(max)=''
	SELECT DISTINCT PlanDate INTO #tmp1 FROM #MrpShipPlan1 ORDER BY PlanDate

	SELECT @SQL=@SQL+'Isnull(['+Convert(varchar(100),PlanDate)+'],0)'+' as ['+PlanDate +'],'
		,@SQL1=@SQL1+'['+PlanDate +'],'
	FROM #tmp1 ORDER BY PlanDate
	IF @SQL!=''
	BEGIN
		SET @SQL =Substring(@SQL,1,LEN(@SQL)-1)
		SET @SQL1 =Substring(@SQL1,1,LEN(@SQL1)-1)	
	END		
	Select 2+COUNT(*) as ColumnCount from #tmp1 
	set @SQL='SELECT Item As 物料, Desc1 物料描述,'+@SQL+' into #Record FROM (select * from #MrpShipPlan1) as D  pivot(max(Qty)'+
	' for PlanDate in ('+@SQL1+')) as PVT order by Item desc; select * from #Record '
	Print @SQL
	EXEC (@SQL)
	
	--Show the data of the second version
	Set @SQL=''
	Set @SQL1=''
	SELECT DISTINCT PlanDate INTO #tmp2 FROM #MrpShipPlan1 ORDER BY PlanDate

	SELECT @SQL=@SQL+'Isnull(['+Convert(varchar(100),PlanDate)+'],0)'+' as ['+PlanDate +'],'
		,@SQL1=@SQL1+'['+PlanDate +'],'
	FROM #tmp2 ORDER BY PlanDate
	IF @SQL!=''
	BEGIN
		SET @SQL =Substring(@SQL,1,LEN(@SQL)-1)
		SET @SQL1 =Substring(@SQL1,1,LEN(@SQL1)-1)	
	END		 
	set @SQL='SELECT Item As 物料, Desc1 物料描述,'+@SQL+' into #Record1 FROM (select * from #MrpShipPlan2) as D  pivot(max(Qty)'+
	' for PlanDate in ('+@SQL1+')) as PVT order by Item desc; select * from #Record1 '
	Print @SQL
	EXEC (@SQL)
END
