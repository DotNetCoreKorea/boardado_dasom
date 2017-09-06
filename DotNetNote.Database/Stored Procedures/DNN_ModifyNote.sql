--[8] 해당 글을 수정하는 저장 프로시저 
CREATE PROCEDURE [dbo].[DNN_ModifyNote]
	@Name		Nvarchar(25),
	@Email		Nvarchar(100),
	@Title		Nvarchar(150),
	@ModifyIp	Nvarchar(15),
	@Content	NText,
	@Password	Nvarchar(30),
	@Encoding	Nvarchar(10),
	@Homepage	Nvarchar(100),
	@FileName	Nvarchar(255),
	@FileSize	Int,

	@Id Int
AS
	Declare @cnt Int

	Select @cnt = Count(*) From Notes
	Where Id = @Id And Password  = @Password 

	If @cnt >0  -- 번호와 암호가 맞는게 있다면...
	Begin
		Update Notes
		Set
			Name = @Name, Email = @Email, Title = @Title,
			ModifyIp = @ModifyIp, ModifyDate =GetDate(),
			Content = @Content, Encoding = @Encoding,
			Homepage = @Homepage, FileName = @FileName, FileSize = @FileSize
		Where Id = @Id

		Select '1'
	End
	Else
		Select '0'
GO