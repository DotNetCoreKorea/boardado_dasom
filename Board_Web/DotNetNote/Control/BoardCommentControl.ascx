﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoardCommentControl.ascx.cs" Inherits="Board_Web.DotNetNote.Control.BoardCommentControl" %>

<asp:Repeater runat="server" ID="ctlCommentList">
    <HeaderTemplate>
        <table style="padding:10px; margin-left:20px; margin-right:20px; width:95%;">
    </HeaderTemplate>
    <ItemTemplate>
        <tr style="border-bottom:1px dotted silver;">
            <td style="width:80px;">
                <%# Eval("Name") %>
            </td>
            <td style="width:350px;">
                <%# Dul.HtmlUtility.Encode(Eval("Opinion").ToString()) %>
            </td>
            <td style="width:180px;">
                <%# Eval("PostDate") %>
            </td>
            <td style="width:10px; text-align:center;">
                <a href=
                    'BoardCommentDelete.aspx?BoardId=<%= Request["Id"] %>&Id=<%# Eval("Id") %>' title="댓글삭제">
                    <img src="../../images/dnn/icon_delete_red.gif" border="0" />
                </a>
            </td>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>

<table style="width:500px; margin-left:auto;" >
    <tr>
        <td style="width:64px; text-align:right;">이 름:</td>
        <td style="width:128px;">
            <asp:TextBox ID="txtName" runat="server" Width="128px" CssClass="form-control" style="display:inline-block;"></asp:TextBox>
        </td>
        <td style="width:64px; text-align:right;">암 호:</td>
        <td style="width:128px;">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="128px" CssClass="form-control" style="display:inline-block;"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnWriteComment" runat="server" Text="의견남기기"  Width="96px" CssClass="form-control btn btn-primary" style="display:inline-block;" OnClick="btnWriteComment_Click" />
        </td>
    </tr>
    <tr>
        <td style="width: 64px; text-align:right;">의 견:</td>
        <td colspan="4" style="width: 448px;">
            <asp:TextBox ID="txtOpinion" runat="server" TextMode="MultiLine" Rows="3" Columns="70" Width="448px" CssClass="form-control" style="display:inline-block;"></asp:TextBox>
        </td>
    </tr>
</table>

<hr />