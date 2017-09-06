--[5] DotNetNote 테이블에 있는 레코드의 개수를 구하는 저장프로시저
CREATE PROCEDURE [dbo].[DNN_GetCountNotes]
AS
	Select Count(*) From Notes
GO
