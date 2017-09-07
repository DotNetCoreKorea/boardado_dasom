<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="BoardModify.aspx.cs" Inherits="Board_Web.DotNetNote.BoardModify" %>
<%@ Register Src="~/DotNetNote/Control/BoardEditorFormControl.ascx" TagPrefix="uc1" TagName="BoardEditorFormControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:BoardEditorFormControl  ID="ctlBoardEditorFormControl" runat="server"/>
</asp:Content>
