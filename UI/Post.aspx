<%@ Page Title="Post" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="XtremeBlog.Post" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">

    
        <link rel="stylesheet" href="http://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.3.0/css/font-awesome.min.css">
        <link href="../Content/font-awesome.min.css" rel="stylesheet" />
        <link href="../froala_editor_1.2.7/css/froala_editor.min.css" rel="stylesheet" />
        <link href="../froala_editor_1.2.7/css/froala_style.min.css" rel="stylesheet" />
     
   
  <section id="editor">
    <form runat="server">
      <asp:TextBox ID="titleTextBox" runat="server" Width="699px" placeholder="Article title here..." ></asp:TextBox><br />
       <textarea id="txtImagename1" name="txtImagename1" rows="1" cols="50"></textarea><br/><br />
       <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click"></asp:Button>>
       <asp:Button ID="publishButton" runat="server" Text="Publish" OnClick="publishButton_Click" ></asp:Button>
       <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
        <br/><br/>
        <div id="msg" runat="server">
            
        </div>
    </form>
  </section>
        <%--<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>--%>
        <script src="../Scripts/jquery-2.1.4.min.js"></script>
        <script src="../froala_editor_1.2.7/js/froala_editor.min.js"></script>
        <!--[if lt IE 9]>
    <<script src="froala_editor_1.2.7/js/froala_editor_ie8.min.js"></script>
  <![endif]-->

        <script src="../froala_editor_1.2.7/js/plugins/tables.min.js"></script>
        <script src="../froala_editor_1.2.7/js/plugins/lists.min.js"></script>
        <script src="../froala_editor_1.2.7/js/plugins/colors.min.js"></script>
        <script src="../froala_editor_1.2.7/js/plugins/media_manager.min.js"></script>
        <script src="../froala_editor_1.2.7/js/plugins/font_family.min.js"></script>
        <script src="../froala_editor_1.2.7/js/plugins/font_size.min.js"></script>
        <script src="../froala_editor_1.2.7/js/plugins/block_styles.min.js"></script>
        <script src="../froala_editor_1.2.7/js/plugins/video.min.js"></script>
      <script>
          $(function () {
              $('#txtImagename1').editable({ inlineMode: false, height: 300,  pastedImagesUploadURL: '/images' ,alwaysBlank: true });
          });
     </script>
   
      
    
</asp:Content>

