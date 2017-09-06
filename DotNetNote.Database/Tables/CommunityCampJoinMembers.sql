CREATE TABLE [dbo].[CommunityCampJoinMembers]
(
	Id INT NOT NULL PRIMARY KEY Identity(1,1),	--일련번호
	CommunityName Nvarchar(25) NOT NULL,		--커뮤니티명
	Name Nvarchar(25) NOT NULL,					--참석자 이름
	Mobile Nvarchar(30) NOT NULL,				--휴대폰 번호	
	Email Nvarchar(100) NOT NULL,				--이메일 주소
	SIze Nvarchar(10) NOT NULL Default('L'),	--티셔츠 기념품 사이즈
	CreationDate DateTime Default(GetDate())	--등록일
)
GO
