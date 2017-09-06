--[2]  댓글 테이블 생성
CREATE TABLE [dbo].[NoteComments]
(
	Id Int Identity(1,1) NOT NULL Primary Key,			-- 일련번호
	BoardName Nvarchar(50) Null,						-- 게시판이름
	BoardId Int Not Null,								-- 해당 게시판의 번호
	Name Nvarchar(25) Not Null,							-- 작성자
	Opinion Nvarchar(4000) Not Null,					-- 댓글내용
	PostDate SmallDateTime Default(GetDate()),			-- 작성일
	Password Nvarchar(20) Not Null						-- 댓글 삭제용 암호
)
GO
