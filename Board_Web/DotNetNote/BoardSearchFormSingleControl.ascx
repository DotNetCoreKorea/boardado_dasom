<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoardSearchFormSingleControl.ascx.cs" Inherits="Board_Web.DotNetNote.BoardSearchFormSingleControl" %>
  <div style="text-align:center;">
            <asp:DropDownList ID="SearchField" runat="server" CssClass="form-control" Width="80px" style="display:inline-block;">
                <asp:ListItem Value="Name">이름</asp:ListItem>
                <asp:ListItem Value="Title">제목</asp:ListItem>
                <asp:ListItem Value="Content">내용</asp:ListItem>
            </asp:DropDownList>&nbsp;
            <asp:TextBox ID="SearchQuery" runat="server" Width="200px" CssClass="form-control" style="display:inline-block;"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator ID="valSearchQuery" Width="200px" runat="server" ControlToValidate="SearchQuery" Display="None" ErrorMessage="검색할 단어를 입력하세요."
                ></asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="false" ShowMessageBox="true"/>
            <asp:Button ID="btnSearch" runat="server" Text="검색" CssClass="form-control" Width="100px" style="display:inline-block;" OnClick="btnSearch_Click" />
        </div>
        <br />
        <% if (!String.IsNullOrEmpty(Request.QueryString["SearchField"]) && !String.IsNullOrEmpty(Request.QueryString["SearchQuery"]))
            {
        %>
            <div style="text-align:center;">
            <a href="/DotNetNote/BoardList.aspx" class="btn btn-success">검색 완료</a>
        </div>
        <%
            }
        %>