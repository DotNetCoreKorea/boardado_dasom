--[1] 게시판 글을 작성
CREATE PROCEDURE [dbo].[WriteNote]
	@Name		Nvarchar(25),
	@Email		Nvarchar(100),
	@Title		Nvarchar(150),
	@PostIp		Nvarchar(15),
	@Content	NText,
	@Password	Nvarchar(20),
	@Encoding	Nvarchar(10),
	@Homepage	Nvarchar(100),
	@FileName	Nvarchar(255),
	@FileSize	Int
AS
	Declare @MaxRef Int 
	Select @MaxRef = MAX(Ref) From Notes

	If @MaxRef is Null  
		Set @MaxRef =1 -- 테이블 생성후 처음만 비교
	Else	
		Set @MaxRef = @MaxRef + 1

	Insert Notes
	(
		Name, Email, Title, PostIp, Content, Password, Encoding, Homepage, Ref, FileName, FileSize
	)
	Values
	(
		@Name, @Email, @Title, @PostIp, @Content, @Password, @Encoding, @Homepage, @MaxRef, @FileName, @FileSize
	)
GO

