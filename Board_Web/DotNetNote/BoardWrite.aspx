<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false"  CodeBehind="BoardWrite.aspx.cs" Inherits="Board_Web.DotNetNote.BoardWrite" %>
<%@ Register Src="~/DotNetNote/Control/BoardEditorFormControl.ascx" TagPrefix="uc1" TagName="BoardEditorFormControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:BoardEditorFormControl  runat="server" ID="ctlBoardEditorFormControl"/>
</asp:Content>
