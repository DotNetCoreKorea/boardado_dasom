﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BoardList.aspx.cs" Inherits="Board_Web.DotNetNote.BoardList" %>

<%@ Register Src="~/DotNetNote/BoardSearchFormSingleControl.ascx" TagPrefix="uc1" TagName="BoardSearchFormSingleControl" %>
<%@ Register Src="~/DotNetNote/AdvancedPagingSingleWithBootstrap.ascx" TagPrefix="uc1" TagName="AdvancedPagingSingleWithBootstrap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align:center;">게시판 리스트</h2>
    <span style="color:#ff0000">글 목록 - 완성형 게시판입니다.</span>
    <hr />
    <table style="width:700px; margin-left:auto; margin-right:auto;">
        <tr>
            <td>
                <style>
                    table th{
                        text-align: center;
                    }
                </style>
                <div style="font-style:italic; text-align:right; font-size:8pt;" >
                    Total Record : 
                    <asp:Literal ID="lblTotalRecord" runat="server"></asp:Literal>
                </div>
                <asp:GridView ID="ctlBoardList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table table-bordered  table-hover table-condensed table-striped table-reponsive">
                    <Columns>
                        <asp:TemplateField HeaderText="번호" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# RecordCount - ((Container.DataItemIndex)) - (PageIndex *10)  %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="제목" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="350px" >
                            <ItemTemplate>
                                <%# Dul.BoardLibrary.FuncStep(Eval("Step")) %>
                                <asp:HyperLink ID="lnkTitle" runat="server" 
                                    NavigateUr='<%# "BoardView.aspx?Id=" + Eval("Id") %>'>
                                    <%# Dul.StringLibrary.CutStringUnicode(Eval("Title").ToString(), 30) %>
                                </asp:HyperLink>
                                <%# Dul.BoardLibrary.ShowCommentCount(Eval("CommentCount")) %>
                                <%# Dul.BoardLibrary.FuncNew(Eval("PostDate")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="파일" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Dul.BoardLibrary.FuncFileDownSingle(Convert.ToInt32(Eval("Id")), Eval("FileName").ToString(), Eval("FileSize").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField  DataField="Name" HeaderText="작성자" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="작성일" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Dul.BoardLibrary.FuncShowTime(Eval("PostDate")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField  DataField="ReadCount" HeaderText="조회수" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="60px"/>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <uc1:AdvancedPagingSingleWithBootstrap runat="server" ID="AdvancedPagingSingleWithBootstrap" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">
            <a href="BoardWrite.aspx" class="btn btn-primary">글쓰기</a>
        </td>
        </tr>
    </table>
     <uc1:BoardSearchFormSingleControl runat="server" ID="BoardSearchFormSingleControl"></uc1:BoardSearchFormSingleControl>
</asp:Content>
