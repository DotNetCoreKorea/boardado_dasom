using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace Board_Web.DotNetNote.Models
{
    public class NoteCommentsRepository
    {
        private SqlConnection con;

        public NoteCommentsRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        }

        public void AddNoteComment(NoteComment model)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@BoardId", value: model.Boardid, dbType: DbType.Int32);
            parameters.Add("@Name", value: model.Name, dbType: DbType.String);
            parameters.Add("@Opinion", value: model.Opinion, dbType: DbType.String);
            parameters.Add("@Password", value: model.Password, dbType: DbType.String);

            string sql = @"Insert Into NoteComments (BoardId, Name, Opinion, Password) Values(@BoardId, @Name, @Opinion, @Password);
                    Update Notes Set CommentCount  = CommentCount +1 
                    Where Id = @BoardId
                    ";

            con.Execute(sql, parameters, commandType: CommandType.Text);
        }

        public List<NoteComment> GetNoteComments(int boardid)
        {
            return con.Query<NoteComment>(
                "Select * From NoteComments Where BoardId = @BoardId"
                , new { BoardId = boardid }
                , commandType: CommandType.Text
                ).ToList();
        }

        public int GetCountBy(int boardId, int id, string password)
        {
            return con.Query<int>(@"Select Count(*) From NoteComments Where BoardId = @BoardId And Id = @Id And Password = @Password"
            , new { BoardId = boardId, Id = id, Password = password }
            , commandType: CommandType.Text).SingleOrDefault();
        }

        public int DeleteNoteComment(int boardId, int id, string password)
        {
            return con.Execute(@"Delete NoteComments Where BoardId = @BoardId And Id = @Id And Password = @Password
                                Update Notes Set CommentCount  = CommentCount -1 Where Id = @BoardId"
                                , new { BoardId = boardId, Id = id, Password = password }
                                , commandType: CommandType.Text);
        }

        public List<NoteComment> GetRecentComments()
        {
            string sql = @"SELECT TOP 3 Id, BoardId, Opinion, PoatDate FROM NoteComments Order By Id Desc";
            return con.Query<NoteComment>(sql).ToList();
        }
    }
}