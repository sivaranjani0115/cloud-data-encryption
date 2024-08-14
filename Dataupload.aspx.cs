using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Net;
public partial class Adminupload : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da;
    DataSet ds;
    string en_file;
    int c=1;
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {



        if (!IsPostBack)
        {
            DropDownList1.Items.Clear();
            cmd = new SqlCommand("select Gname from Joingroup where Uname='" + Session["User"].ToString() + "'", con);
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                DropDownList1.Items.Add(dr1[0].ToString());
            }
            con.Close();

            //  bgrid();
            bgrid1();
        }
    }
    string output;
    protected void Button1_Click(object sender, EventArgs e)
    {
        //


        string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "doc", "xls","txt","pdf" };

        string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);

        bool isValidFile = false;

        for (int i = 0; i < validFileTypes.Length; i++)
        {

            if (ext == "." + validFileTypes[i])
            {

                isValidFile = true;

                break;

            }

        }

        if (!isValidFile)
        {
       
            if (con.State == ConnectionState.Closed) con.Open();
            cmd = new SqlCommand("insert into Invalidfile values('" + Session["User"].ToString() + "','" + System.DateTime.Now.ToShortDateString() + "','" + Dns.GetHostName().ToString() + "')", con);
            cmd.ExecuteNonQuery();

               Response.Write("<script>alert('Threats Found')</script>");
       
            
        }

        else
        {
            //file upload new code
            if (TextBox3.Text == "" | FileUpload1.FileName == "")
            {
                Response.Write("<script>alert('Please Fill the All Column')</script>");


            }
            else
            {
                try
                {
                    string dt = System.DateTime.Now.ToString();
                    //Get the Input File Name and Extension.
                    string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

                    //Build the File Path for the original (input) and the encrypted (output) file.
                    string input = Server.MapPath("~/Files/") + fileName + fileExtension;
                    string input1 = Server.MapPath("~/Upload/") + fileName + fileExtension;
                    output = Server.MapPath("~/Files/") + fileName + "_enc" + fileExtension;

                    //Save the Input File, Encrypt it and save the encrypted file in output path.
                    FileUpload1.SaveAs(input);
                    FileUpload1.SaveAs(input1);
                    this.Encrypt(input, output);

                    File.Delete(input);
                    TextBox1.Text = File.ReadAllText(output);


                    if (FileUpload1.HasFile)
                    {
                        // System.IO.FileInfo fileInfo = new System.IO.FileInfo(FileUpload1.PostedFile.FileName);
                        //System.IO.FileInfo fileInfo = new Server(FileUpload1.PostedFile.FileName);
                        string dest = Server.MapPath("Upload\\" + FileUpload1.FileName.ToString());
                        FileUpload1.SaveAs(dest);
                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(dest);
                        string ftype = FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf(".") + 1, (FileUpload1.FileName.Length - FileUpload1.FileName.LastIndexOf(".") - 1));
                        int filesize = FileUpload1.PostedFile.ContentLength;
                        if (con.State == ConnectionState.Closed) con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Fileupload values('" + FileUpload1.PostedFile.FileName + "','" + TextBox3.Text + "','" + dt + "','" + TextBox4.Text + "','" + Session["User"].ToString() + "','" + DropDownList1.Text + "')", con);
                        cmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Upload Successfull');</script>");

                    }
                }
                catch
                {
                }

            }
            bgrid1();
    
       


            //
          
        }

    

       
    }

    private void Encrypt(string inputFilePath, string outputfilePath)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
            {
                using (CryptoStream cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                    {
                        int data;
                        while ((data = fsInput.ReadByte()) != -1)
                        {
                            cs.WriteByte((byte)data);
                        }
                    }
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Adminupload.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        
        

       
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
     
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
       
    }

   

    private void bgrid1()
    {

        con.Close();
        con.Open();
        da = new SqlDataAdapter("select Fileid,Filename,Description,uptime,Fkey,Groupname from Fileupload where Dataowner='" + Session["User"].ToString() + "'", con);
        ds = new DataSet();
        da.Fill(ds);
        GridView2.DataSource = ds;
        GridView2.DataBind();
        con.Close();


    }


    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        con.Open();
        try
        {
            string str = GridView2.Rows[e.RowIndex].Cells[1].Text;
            cmd = new SqlCommand("delete from Fileupload where Fileid=" + str + "", con);
            cmd.ExecuteNonQuery();
            GridView2.EditIndex = -1;
            con.Close();
            bgrid1();
        }
        catch (Exception ex)
        {

        }


    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button3_Click1(object sender, EventArgs e)
    {

        

    }

    public string saltValue = "s@1tValue";        // can be any string
    public string hashAlgorithm = "SHA1";        // can be "MD5"
    public int passwordIterations = 2;          // can be any number
    public int keySize = 256;                  // can be 192 or 128
    string initVector = "@1B2c3D4e5F6g7H8";   // must be 16 bytes
    protected void Button3_Click2(object sender, EventArgs e)
    {
       

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Random r = new Random();
        int rnd = r.Next(2000000);
        TextBox4.Text = Convert.ToString(rnd);
    }
}
