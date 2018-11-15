<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CrownPeakDemo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div id="GameContainer" runat="server">
    <h2>Current Neighborhood</h2>
    <div id="CurrentNeighbourhood" runat="server"></div>
    <h2>New Neighborhood</h2>
    <div id="NewNeighbourhood" runat="server"></div>
</div><br />
<a href="EnterGameBoard.aspx">Enter a new game</a>
</asp:Content>