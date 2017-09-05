<%@ Page Title="회원관리 -메인페이지" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DevUser._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
       <h1>회원 관리</h1>
        <h2>메인 페이지</h2>

        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                <!--로그인 전-->
                <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="로그인" /> |
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Register.aspx">회원가입
                </asp:HyperLink>
            </AnonymousTemplate>
            <LoggedInTemplate>
                <!--로그인 후-->
                <asp:LoginStatus ID="LoginStatus2" runat="server" LogoutText="로그아웃" Visible="false" />
                <a href="Logout.aspx">로그아웃</a>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Welcome.aspx">
                    <asp:LoginName ID="LoginName1" runat="server" />
                </asp:HyperLink>
            </LoggedInTemplate>
        </asp:LoginView>
    </div>

</asp:Content>
