--[1] 게시판(DotNetNote) 용 테이블 설계
CREATE TABLE [dbo].[Notes]
(
	Id Int Identity(1,1) Not Null Primary key,		--번호
	Name Nvarchar(25) Not Null,						--이름
	Email Nvarchar(100) Null,						--이메일
	Title Nvarchar(150) Not Null,					--제목
	PostDate DateTime Default GetDate() Not Null,	--작성일
	PostIp Nvarchar(15) Null,						--작성IP
	Content NText Not Null,							--내용
	Password Nvarchar(20) Null,						--비밀번호
	ReadCount Int Default 0,						--조회수
	Encoding Nvarchar(10) Not Null,					--인코딩
	Homepage Nvarchar(100) Null,					--홈페이지
	ModifyDate DateTime Null,						--수정일
	ModifyIp Nvarchar(15) Null,						--수정IP
	FileName Nvarchar(255) Null,					--파일명		
	FileSize Int Default 0,							--파일크기
	DownCount Int Default 0,						-- 다운수
	Ref Int Not Null,								-- 참조(부모글)
	Step Int Default 0,								-- 답변레벨
	RefOrder Int Default 0,							-- 답변순서
	AnswerNum Int default 0,						-- 답변수
	ParentNum Int Default 0,						-- 부모글번호
	CommentCount Int Default 0,						-- 댓글수
	Category Nvarchar(10) Null						-- 카테고리(확장)
)
GO