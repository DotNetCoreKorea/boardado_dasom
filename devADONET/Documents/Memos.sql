--[1] 한줄 메모장(Memos) 테이블 설계
CREATE TABLE dbo.Memos
(
	Num  Int Identity(1,1) Primary Key,
	Name Nvarchar(25) NOT NULL,
	Email Nvarchar(100) NULL,
	Title Nvarchar(150) NOT NULL,
	PostDate DateTime Default(GetDate()),
	PostIP Nvarchar(15) NULL
)
GO

--[2] SQL 예시문 6가지 작성
--[a] 입력 예시문 :Insert:FrmMemoWrite.aspx
Insert Memos Values(
	N'레드플러스', N'redplus@devlect.com', N'레드플러스입니다.', GETDATE(), '127.0.0.1'
)
GO

--[b] 출력 예시문:Select 문:FrmMemoList.aspx
Select Num, Name, Email, Title, PostDate, PostIP FROM Memos Order BY Num Desc
GO

--[c] 상세 예시문:Select 문:FrmMemoView.aspx
SELECT Num, Name, Email, Title, PostDate, PostIP FROM Memos where Num=1
GO

--[d] 수정 예시문:Update 문:FrmMemoModify.aspx
Begin Tran 
	Update Memos 
		Set  Name=N'백두산',
			 Email=N'admin@devlec.com',
			 Title=N'백두산입니다.',
			 PostIP=N'127.0.0.1'
		where
			Num=1
--RollBack Tran
Commit Tran
GO

--[e] 삭제 예시문:Delete문:FrmMemoDelete.aspx
Begin Tran 
	Delete Memos Where Num =10
Commit Tran
GO

--[f] 검색 예시문: Select문 : FrmMemoSearch.aspx
--Memos에서 이름이 레드플러스이거나 또는
--이메일에 'r'가 들어가는 자료의 모든 필드
-- 번호의 역순으로 검색

select Num, Name, Email, Title, PostDate  
	FROM Memos where Name='레드플러스' 
	Or 
	Email Like '%r%' 
	Order By Num Desc
GO

--[3] SQL 저장프로시저 6가지 작성

--[a] 메모 입력용 저장 프로시저
Create Procedure dbo.writeMemo
(
	@Name  Nvarchar(25),
	@Email Nvarchar(100),
	@Title Nvarchar(150),
	@PostIP Nvarchar(15)

)AS
	 Insert Memos(Name, Email, Title, PostIP)
	 Values(@Name, @Email, @Title, @PostIP)
 GO

 --[b] 메모 출력용 저장 프로시저
 Create Proc dbo.ListMemo
 AS 
	select Num, Name, Email, Title, PostDate, PostIP
	FROM Memos Order By Num Desc
Go


--[c] 메모 상세보기용 저장 프로시저
Create Proc dbo.ViewMemo
(
	@Num Int
)
AS 
	select Num, Name, Email, Title, PostDate, PostIP
	FROM Memos
	where Num =  @Num
GO

--[d] 메모 데이터 수정용 저장 프로시저
Create proc dbo.ModifyMemo
(
	@Name Nvarchar(25),
	@Email Nvarchar(100),
	@Title Nvarchar(150),
	@Num Int
)
AS
Begin Transaction 
		Update Memos
	Set
		Name = @Name,
		Email= @Email,
		Title = @Title
	where Num = @Num
Commit Transaction
GO
--[e] 메모 데이터 삭제용 저장 프로시저
Create proc dbo.DeleteMemo
(
	@Num Int
)
AS
 Delete Memos
 where Num = @Num
 GO


 --[f] 메모 데이터 검색용 저장 프로시저(동적SQL 사용)
 Create Proc dbo.SearchMemo
 (
	@SearchField Nvarchar(10),
	@SearchQuery Nvarchar(50)
 )
 --with Encryption  현재 -SP 암호화-
 As
	Declare @strSql Nvarchar(150)
	Set @strSql=
	'
	Select Num, Name, Email, Title, PostDate, PostIP
	FROM Memos
	where ' + @SearchField + ' Like 
	N''%'+ @SearchQuery +'%''
	Order By Num Desc
	'
	Exec (@strSql)
GO
