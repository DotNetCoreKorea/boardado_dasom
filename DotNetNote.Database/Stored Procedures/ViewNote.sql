--[3] 해당 글을 세부적으로 읽어 오는 저장 프로시저
CREATE PROCEDURE [dbo].[ViewNote]
	@Id Int
AS
	-- 조회수 카운트 1증가
	Update Notes Set ReadCount = ReadCount  + 1 where Id = @Id

	-- 모든 항목 조회
	Select * From Notes where Id= @Id
GO
