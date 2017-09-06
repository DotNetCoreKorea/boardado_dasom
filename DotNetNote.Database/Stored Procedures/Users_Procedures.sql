--[User][0][2] Users 관련 저장 프로시저 생성
-- 스토어드 프로시저(stored procedure)는 일련의 쿼리를 마치 하나의 함수처럼 실행하기 위한 쿼리의 집합이다.

--[1] 입력 저장 프로시저
Create Proc dbo.WriteUsers
	@UserID NVarchar(25),
	@Password NVarchar(20)
AS
	Insert Into Users Values(@UserID, @Password)
GO

--[2] 출력 저장 프로시저
Create Proc dbo.ListUsers
AS
	Select [UID],[UserID],[Password] From Users Order By UID Desc
GO

--[3] 상세 저장 프로시저
Create Proc dbo.ViewUsers
	@UID Int
AS
	Select [UID], [UserID], [Password] From Users Where UID = @UID
GO

--[4] 수정 저장 프로시저
Create Proc dbo.ModifyUsers
	@UserID NVarchar(25),
	@Password NVarchar(20),
	@UID Int
AS
	Begin Tran
		Update Users
		Set
			UserID = @UserID,
			[Password] =@Password
		Where UID = @UID
	Commit Tran
GO

--[5] 삭제 저장 프로시저
Create Proc dbo.DeleteUsers
	@UID Int
AS
	Delete Users Where UID =@UID
GO

--[6] 검색 저장 프로시저
Create Proc dbo.SearchUsers
	@SearchField NVarchar(25),
	@SearchQuery NVarchar(25)
AS
	Declare @strSql NVarchar(255)
	Set @strSql ='
		Select * From Users
		Where 
			'+@SearchField +' Like ''%' + @SearchQuery + '%'''Exec(@strSql)
GO